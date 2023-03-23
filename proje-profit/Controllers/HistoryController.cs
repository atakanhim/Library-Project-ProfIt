using BL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using proje_profit.Models;

namespace proje_profit.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService _historyService;
        private IBookService _bookService;
        public HistoryController(IHistoryService historyService, IBookService bookService)
        {
            _historyService = historyService;
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOutView(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOutView(History history)
        {
            try
            {
                if (history.CheckOutDate == null)
                    history.CheckOutDate = DateTime.Now;
                _historyService.AddHistory(history);

                _bookService.ChangeCheckOutStatus(history.BookId);
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CheckInView(int id)
        {

               var model = _historyService.GetHistory(id);
               
                if (model == null) 
                return View();



            return View(model);
        }
    }
}
