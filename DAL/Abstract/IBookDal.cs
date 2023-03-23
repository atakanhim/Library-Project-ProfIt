using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IBookDal:IEntityRepository<Book>
    {
        bool ChangeCheckOutStatus(int id);
    }
}
