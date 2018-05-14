using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcExample.Domain.Interfaces;
using MvcExample.Domain.Models.Books;
using MvcExample.Web.Models.Books;

namespace MvcExample.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = _bookService.QueryBooks().ToList();
            
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
            var viewModel = new BooksCreateViewModel();
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