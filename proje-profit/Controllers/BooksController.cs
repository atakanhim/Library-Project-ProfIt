using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using BL.Abstract;

namespace proje_profit.Controllers
{
    public class BooksController : Controller
    {
    
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: Books
        public IActionResult Index()
        {
              return View(_bookService.GetAll());
        }

       

    }
}
