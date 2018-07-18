using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Cqrs.Queries.Models;
using MvcExample.Data;
using MvcExample.Data.Entities;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Books;
using MvcExample.Web.Models.Books;
using MvcExample.Web.Models.Shared;

namespace MvcExample.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataContext _context;
        private readonly IQueryProcessor _queryProcessor;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(
            DataContext context,
            IQueryProcessor queryProcessor,
            IBookService bookService,
            IMapper mapper)
        {
            _context = context;
            _queryProcessor = queryProcessor;
            _bookService = bookService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _queryProcessor.Query<BooksQuery, BookDto>(new BooksQuery());

            //var books = await _context.Books.Select(book => new BookDto
            //{
            //    Title = book.Title,
            //    ReleaseDate = book.ReleaseDate,
            //    AuthorFirstName = book.Author.FirstName,
            //    AuthorLastName = book.Author.LastName,
            //    OtherBooksByAuthor = book.Author.Books.Where(_ => _.Id != book.Id).Select(_ => new BookDto
            //    {
            //        Title = _.Title,
            //        ReleaseDate = _.ReleaseDate,
            //        AuthorFirstName = _.Author.FirstName,
            //        AuthorLastName = _.Author.LastName
            //    }).ToList()
            //}).ToListAsync();

            var test = _mapper.ConfigurationProvider.ExpressionBuilder.GetMapExpression(typeof(Book), typeof(BookDto),
                new Dictionary<string, object>(), new List<MemberInfo>().ToArray());

            Expression<Func<string>> test2 = () => "test";

            // TODO: Consider how to make this more decoupled
            var viewModel = new BooksIndexViewModel
            {
                Books = books
            };

            return await Task.FromResult(View(viewModel));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await _queryProcessor.Query<AuthorsQuery, AuthorSelectable>(new AuthorsQuery());
            var viewModel = new BooksCreateViewModel {Authors = authors};

            return await Task.FromResult(View(viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BooksCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var newBook = new CreateBookDto
            {
                AuthorId = viewModel.AuthorId,
                Title = viewModel.Title,
                ReleaseDate = viewModel.ReleaseDate
            };

            await _bookService.CreateBook(newBook, Guid.NewGuid());

            return RedirectToAction(nameof(Index));
        }
    }
}