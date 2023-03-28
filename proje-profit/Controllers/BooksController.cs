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
using Newtonsoft.Json;
using proje_profit.Models;

namespace proje_profit.Controllers
{
    public class BooksController : Controller
    {
    
        private readonly ILogger<BooksController> logger;
        private IBookService _bookService;

        public BooksController(IBookService bookService , ILogger<BooksController> logger)
        {
            this.logger = logger;
            _bookService = bookService;
        }

        // GET: Books
        public IActionResult Index()
        {

        
                if (TempData["alert"] != null)
                {
                    var data = TempData["alert"].ToString();
                    var err = JsonConvert.DeserializeObject<AlertModel>(data);
                     ViewData["error"]= err;
                }

            try
            {
                return View(_bookService.GetAll());
            }
            catch
            {
                logger.LogError("Kitaplar listelenemedi");
                return View();
            }
        }

       

    }
}
