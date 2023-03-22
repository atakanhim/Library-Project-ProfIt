using Core.DataAccess.Concrete.EntityFramework;
using DAL.Abstract;
using DAL.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book,DataContext>, IBookDal
    {
      
    }
}
