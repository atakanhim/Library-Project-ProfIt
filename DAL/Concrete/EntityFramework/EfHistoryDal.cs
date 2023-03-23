using Core.DataAccess.Concrete.EntityFramework;
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
    public class EfHistoryDal : EfEntityRepositoryBase<History, DataContext>, IHistoryDal
    {
     
        public History GetHistoryWithBook(Expression<Func<History, bool>> filter)
        {
            using (DataContext c = new DataContext())
            {

                return c.Histories.Include(x => x.Book).Where(filter).FirstOrDefault();

            }
        }
    }
}
