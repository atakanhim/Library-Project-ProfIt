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

        public string? UserName { get; set;}

        public long? UserPhone { get; set;}

        public long? UserTc { get; set; }

        public DateTime? CheckOutDate{ get; set; } = DateTime.Now;// kitap cikis tarihi seciliyor varsayılan deger siimdi.

        public DateTime? ExpectedCheckoutDate { get; set; } = DateTime.Now.AddDays(15);// aynı kodu eger baska gun

        public DateTime? CheckInDate { get; set; } = null;// gerçekleşen teslim tarihi 

        public double PriceTotal { get; set; } = 0;

        public bool HistoryStatus { get; set; }// false ise Status kapanmıs
           // ve fiyat ödenmiş ve kitap tekrardan checkout durumuna geçmiş demektir. 
           //True ise bu kitap alinmiş ama geri verilmmeiş demektir.
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
 



    }
}
