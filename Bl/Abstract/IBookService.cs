using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IBookService
    {

        List<Book> GetAll();


        bool ChangeCheckOutStatus(int id);


    }
}
