using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Abstract;
using DAL.Abstract;
using DAL.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, DataContext>, IBookDal
    {
        public bool ChangeCheckOutStatus(int id)
        {
            // book id aldıj
            try
            {
                using (DataContext context = new DataContext())
                {
                    //var addedEntity =   context.Entry(entity); // eklenen entity
                    //  addedEntity.State = EntityState.Added;
                    var book = context.Books.Where(x=>x.BookId == id).FirstOrDefault();
                    if (book != null)
                    {
                        if (book.CheckOutStatus == true)
                            book.CheckOutStatus = false;
                        else 
                            book.CheckOutStatus = true;
                    }
                    context.SaveChanges();
                    
                }
                return true;
            }
            catch { return false; }
        }
    }
}
