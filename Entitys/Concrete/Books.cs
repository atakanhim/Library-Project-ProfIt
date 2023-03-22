using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Books:IEntity
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string? BookTitle { get; set; }
        [Required]
        public string? BookAuthor { get; set;}
        [Required]
        [MaxLength(13)]
        public string? ISBN { get; set; }
        [Required]
        public DateTime? PublicationDate { get; set; }// Yayin Yılı
        [Required]
        public double Price { get; set; }
        [Required]
        public bool CheckOutStatus { get; set; }// True = CheckOut yapılabilir anlamadında ,
                                                // false ise kitap başka birinde demek.




    }
}
