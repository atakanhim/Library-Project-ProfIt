namespace proje_profit.Models
{
   
    public class Rootobject
    {
        public CrudModel[] Property1 { get; set; }
    }

    public class CrudModel
    {
        public string _id { get; set; }
        public string category_id { get; set; }
        public string category_description { get; set; }
        public string category_name { get; set; }
        public string category_image { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int __v { get; set; }
    }

}
