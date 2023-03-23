using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHistoryService
    {
        List<History> GetAll();

        History GetHistoryWithBook(Expression<Func<History, bool>> filter);
        

        void UpdateHistory(History history);

        void AddHistory(History History);
    }
}
