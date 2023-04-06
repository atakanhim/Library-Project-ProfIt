using BL.Abstract;
using Core.DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using proje_profit.Models;

namespace proje_profit.Controllers
{
    [Authorize(Roles = "admin")] // sadece admin özel
    public class HistoryController : Controller
    {
        private IHistoryService _historyService;
        private IBookService _bookService;
        private ItcknValidator _validator;
   
        private readonly ILogger<BooksController> logger;
        public HistoryController(IHistoryService historyService, IBookService bookService, ILogger<BooksController> logger, ItcknValidator validator)
        {
            _historyService = historyService;
            _bookService = bookService;
            _validator = validator;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOutView(int id)
        {
            ViewData["data"] = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOutView(History history)
        {
            var alertModel = new AlertModel()
            {
                title = "Check-Out islemi basarili",
                icon = Icon.success
            };


            var donus = _validator.Validate(history.UserTc.ToString());
            if (donus == false)
            {

                alertModel.title = "Gecersiz Tc Kimlik Numarası gecersiz oldugundan islem gerceklestirilemedi.";
                alertModel.icon = Icon.error;
                TempData["alert"] = JsonConvert.SerializeObject(alertModel);
                return RedirectToAction("Index", "Books");
            }
            else
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
                    alertModel.title = "CheckOut işlemi yapilamadi";
                    alertModel.icon = Icon.error;
                    TempData["alert"] = JsonConvert.SerializeObject(alertModel);
                    return RedirectToAction("Index", "Books");
                }
            }
          

            TempData["alert"] = JsonConvert.SerializeObject(alertModel);
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

            var alertModel = new AlertModel()
            {
                title = "Check-In islemi basarili",
                icon = Icon.success
            };

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

                alertModel.title = "CheckIn işlemi yapilamadi";
                alertModel.icon = Icon.error;
                TempData["alert"] = JsonConvert.SerializeObject(alertModel);
                return RedirectToAction("Index", "Books");
            }



            TempData["alert"]  = JsonConvert.SerializeObject(alertModel);
            return RedirectToAction("Index", "Books");
        }
    }
}
