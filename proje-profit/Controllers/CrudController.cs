using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using proje_profit.Models;

namespace proje_profit.Controllers
{
    public class CrudController : Controller
    {
        IHttpClientFactory _httpClientFactory;
        public string ApiUrl { get; set; }
        public CrudController(IHttpClientFactory httpClientFactory)
        {
   
                this._httpClientFactory = httpClientFactory;
                this.ApiUrl = "https://server-atakanhm.onrender.com/"; 
        
        }

        public IActionResult Index()
        {
          
            
            return View();
        }
        public async Task<IActionResult> GetCategory(int? id)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            //var response = await httpClient.GetAsync(this.ApiUrl + "api/category");
            //var responseString = await response.Content.ReadAsStringAsync(); // datayı okunabilir kıldık
            //List<CrudModel> crudModel = JsonConvert.DeserializeObject<List<CrudModel>>(responseString);

            var response = await httpClient.GetAsync(this.ApiUrl + "api/menu");
            var responseString = await response.Content.ReadAsStringAsync(); // datayı okunabilir kıldık
            List<MenuModel> crudModel = JsonConvert.DeserializeObject<List<MenuModel>>(responseString);





            return RedirectToAction("Index");
        }
    } 
}
