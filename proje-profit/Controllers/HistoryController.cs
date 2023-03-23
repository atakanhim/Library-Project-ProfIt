using Microsoft.AspNetCore.Mvc;

namespace proje_profit.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOutView(int id)
        {
            return View();
        }
        public IActionResult CheckInView(int id)
        {
            return View();
        }
    }
}
