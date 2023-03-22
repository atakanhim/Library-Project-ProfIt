using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string? UserTc { get; set; }
        [Required]
        public int BookId { get; set;}
        [Required]
        public int PriceTotal { get; set;} = 0;


    }
}
