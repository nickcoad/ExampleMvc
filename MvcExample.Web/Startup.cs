using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcExample.Cqrs;
using MvcExample.Cqrs.Commands.Decorators;
using MvcExample.Cqrs.Commands.Interfaces;
using MvcExample.Cqrs.Commands.Validators;
using MvcExample.Cqrs.Domain;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Cqrs.Queries;
using MvcExample.Cqrs.Queries.Handlers;
using MvcExample.Cqrs.Queries.Interfaces;
using MvcExample.Data;
using MvcExample.Domain.Interfaces;
using MvcExample.Web.Data;
using MvcExample.Web.Models;
using MvcExample.Web.Services;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace MvcExample.Web
{
    public class Startup
    {
        private readonly Container _container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("server=localhost;database=cqrs_example;username=postgres;password=password"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddMvc();

            IntegrateSimpleInjector(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitialiseContainer(app);

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitialiseContainer(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            // Infrastructural stuff
            _container.Register<IQueryProcessor, QueryProcessor>();
            _container.RegisterInstance<IMapper>(new Mapper(ConfigureAutoMapper()));

            // Domain logic
            _container.Register<IAuthorService, AuthorService>();
            _container.Register<IBookService, BookService>();

            // CQRS
            _container.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
            _container.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidateCommandDecorator<>));
            _container.Register(typeof(IQueryHandler<,>), typeof(AuthorsQueryHandler<>));
            _container.Register(typeof(IQueryHandler<,>), typeof(BooksQueryHandler<>));

            // CQRS Validators
            _container.Register(typeof(IValidator<>), typeof(IValidator<>).Assembly);
            _container.RegisterConditional(typeof(IValidator<>), typeof(AlwaysValidValidator<>), _ => !_.Handled);

            _container.AutoCrossWireAspNetComponents(app);
        }

        public IConfigurationProvider ConfigureAutoMapper()
        {
            var conf = new MapperConfiguration(_ => _.AddProfiles(Assembly.GetExecutingAssembly()));
            return conf;
        }

        public void IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }
    }
}
