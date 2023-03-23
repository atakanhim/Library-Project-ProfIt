using BL.Abstract;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Concrete
{
    public class HistoryManager : IHistoryService 
    {
        private  IHistoryDal _historyDal;
        public HistoryManager(IHistoryDal historyDal)
        {
            _historyDal = historyDal;
        }

        public void AddHistory(History history)
        {
            _historyDal.Add(history);
        }

        public List<History> GetAll()
        {
           return _historyDal.GetList();
        }

        public History GetHistoryWithBook(Expression<Func<History, bool>> filter)
        {
           var History = _historyDal.GetHistoryWithBook(filter);
            return History?? null;
        }
    }
}
