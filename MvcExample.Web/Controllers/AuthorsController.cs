using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcExample.Cqrs.Interfaces;
using MvcExample.Cqrs.Queries.Models;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Authors;
using MvcExample.Web.Models.Authors;

namespace MvcExample.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly IAuthorService _authorService;

        public AuthorsController(
            IQueryProcessor queryProcessor,
            IAuthorService authorService)
        {
            _queryProcessor = queryProcessor;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _queryProcessor.Query<AuthorsQuery, AuthorDto>(new AuthorsQuery());
            
            var viewModel = new AuthorsIndexViewModel
            {
                Authors = authors
            };

            return await Task.FromResult(View(viewModel));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new AuthorsCreateViewModel();
            return await Task.FromResult(View(viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorsCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var newAuthor = new CreateAuthorDto
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };

            await _authorService.CreateAuthor(newAuthor, Guid.NewGuid());

            return RedirectToAction(nameof(Index));
        }
    }
}