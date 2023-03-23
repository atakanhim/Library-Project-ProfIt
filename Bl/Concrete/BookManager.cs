using BL.Abstract;
using DAL.Abstract;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class BookManager:IBookService
    {

        private IBookDal _bookDal;
        public BookManager(IBookDal bookdal)
        {
            _bookDal = bookdal;
        }

        public bool ChangeCheckOutStatus(int id)
        {
            return _bookDal.ChangeCheckOutStatus(id);
        }

        public List<Book> GetAll()
        {
            return _bookDal.GetList();
        }
    }
}
