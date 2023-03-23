using Core.DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IHistoryDal:IEntityRepository<History>
    {
        History GetHistoryWithBook(Expression<Func<History, bool>> filter);
        // Repositroy pattern
        //listeleme
        //ekleme
        //silme
        //güncelleme
    }
}
