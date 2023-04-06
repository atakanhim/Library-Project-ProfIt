using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace proje_profit.Components
{
    public class BookViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
          

    }
}
