using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class History:IEntity
    {
        [Key]
        public int HistoryId { get; set; }
        [Required]
        public string? UserName { get; set;}
        [Required]
        public string? UserPhone { get; set;}
        [Required]
        [MaxLength(11)]
        public long? UserTc { get; set; }
        [Required]
        public DateTime? CheckOutDate{ get; set; } = DateTime.Now;// kitap cikis tarihi seciliyor varsayılan deger siimdi.
        [Required]
        public DateTime? ExpectedCheckoutDate { get; set; } = DateTime.Now.AddDays(15);// aynı kodu eger baska gun
                                                                                       // check out yapacaksakta secmemiz gerekecek
        [Required]
        public DateTime? CheckInDate { get; } = null;// gerçekleşen teslim tarihi 
        [Required]
        public double PriceTotal { get; set; } = 0;

        [Required]
        public bool HistoryStatus { get; set; }// false ise Status kapanmıs
           // ve fiyat ödenmiş ve kitap tekrardan checkout durumuna geçmiş demektir. 
           //True ise bu kitap alinmiş ama geri verilmmeiş demektir.

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
 



    }
}
