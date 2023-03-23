using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Abstract
{
    public interface IHistoryService
    {
        List<History> GetAll();

        History GetHistory(int id);
    //    List<History> GetByCategory(int categoryId);

        void AddHistory(History History);
    }
}
