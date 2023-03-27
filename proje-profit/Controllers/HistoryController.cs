using BL.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace proje_profit.Controllers
{
    public class HistoryController : Controller
    {
        private IHistoryService _historyService;
        private IBookService _bookService;
        private readonly ILogger<BooksController> logger;
        public HistoryController(IHistoryService historyService, IBookService bookService, ILogger<BooksController> logger)
        {
            _historyService = historyService;
            _bookService = bookService;
            this.logger = logger;
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
                DateTime? _checkoutdate = history.CheckOutDate;
                if (_checkoutdate == null)
                    history.CheckOutDate = DateTime.Now;
                else if (_checkoutdate.HasValue)
                {
                    // yeni bir checkout date girildigi zaman 15 gün sonrasına süre veriyor onun dısında defult deger zate 15 gün
                    DateTime date = new DateTime(history.CheckOutDate.Value.Ticks).AddDays(15);
                    history.ExpectedCheckoutDate = date;
                }

                _historyService.AddHistory(history);
                _bookService.ChangeCheckOutStatus(history.BookId);
            }
            catch (Exception)
            {
                logger.LogError("CheckOut-Post işlemi yapılırken bir hata ile karşılaşıldı.");
                throw;
            }
            return RedirectToAction("Index", "Books");
        }
        public IActionResult CheckInView(int id)
        {    

               var model = _historyService.GetHistoryWithBook(x=>x.BookId==id);
            var totaldays = (model.ExpectedCheckoutDate - DateTime.Now);
                

                if (model == null)
                  {
                        logger.LogError("CheckIn-Get işlemi yapılırken bir hata ile karşılaşıldı.");
                        return View();
                  }
              
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
                logger.LogError("CheckIn-Post işlemi yapılırken bir hata ile karşılaşıldı.");
                throw;
            }
            return RedirectToAction("Index", "Books");
        }
    }
}
