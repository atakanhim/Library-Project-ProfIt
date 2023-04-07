

namespace proje_profit.Models
{
    public class MenuModel
    {
        public string _id { get; set; }
        public string menu_id { get; set; }
        public string menu_name { get; set; }
        public object[][] menu_burger_selection { get; set; }
        public object[][] menu_cips_selection { get; set; }
        public object[] menu_snacks_selection { get; set; }
        public object[][] menu_drink_selection { get; set; }
        public object[][] menu_sauce_selection { get; set; }
        public int menu_price { get; set; }
        public string menu_image { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

    public class Rootobjectt
    {
        public MenuModel[] Property1 { get; set; }
    }
}
