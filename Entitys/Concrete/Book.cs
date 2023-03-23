using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        [Key]
        public int BookId { get; set; }
        public string? BookTitle { get; set; }
        public string? BookAuthor { get; set;}
        public string? ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }// Yayin Yılı
        public double Price { get; set; }
        public bool CheckOutStatus { get; set; }// True = CheckOut yapılabilir anlamadında ,
                                                // false ise kitap başka birinde demek.




    }
}
