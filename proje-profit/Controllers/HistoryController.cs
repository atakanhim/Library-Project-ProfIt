using BL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using proje_profit.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

                var myNewDate = history.CheckOutDate.Value.AddDays(15);


                DateTime? _checkoutdate = history.CheckOutDate;
                if (_checkoutdate == null)
                    history.CheckOutDate = DateTime.Now;
                else if (_checkoutdate > DateTime.Now)// client tarafındada küçükse kontrl edilcel
                    history.ExpectedCheckoutDate=myNewDate.Date;

                

                _historyService.AddHistory(history);


                _bookService.ChangeCheckOutStatus(history.BookId);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Books");
        }
        public IActionResult CheckInView(int id)
        {    

               var model = _historyService.GetHistoryWithBook(x=>x.BookId==id);
            var totaldays = (model.ExpectedCheckoutDate - DateTime.Now);
                

                if (model == null) 
                return View();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckInView(History history)
        {
            var historyModel = _historyService.GetHistoryWithBook(x => x.HistoryId == history.HistoryId);
            historyModel.HistoryStatus = true; // history kapadık
            historyModel.CheckInDate = DateTime.Now; // bugun yaptik kapadik
            historyModel.PriceTotal = Convert.ToDouble(history.PriceTotal);

            try
            {
                _historyService.UpdateHistory(historyModel);
                _bookService.ChangeCheckOutStatus(historyModel.BookId);// bu kısımda da kitap tekrar alınabilir hale getiriyoruz.
            }
            catch(Exception)
            {
                throw;
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
