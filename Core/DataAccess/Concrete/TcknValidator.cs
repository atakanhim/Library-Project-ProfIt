 using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class TcknValidator:ItcknValidator
    {
       
        public bool Validate(string TCKN)
        {
            if (TCKN.Length != 11)
                return false;
            int sumFirst = int.Parse(TCKN[0].ToString()) + int.Parse(TCKN[2].ToString()) + int.Parse(TCKN[4].ToString()) + int.Parse(TCKN[6].ToString()) + int.Parse(TCKN[8].ToString());
            sumFirst *= 7;
            int sumSecond = int.Parse(TCKN[1].ToString()) + int.Parse(TCKN[3].ToString()) + int.Parse(TCKN[5].ToString()) + int.Parse(TCKN[7].ToString());
            sumSecond *= 9;
            int sumTotal = sumFirst + sumSecond;
            if (int.Parse(TCKN[9].ToString()) != (sumTotal % 10) || ((sumFirst + sumSecond + int.Parse(TCKN[9].ToString())) % 10) != int.Parse(TCKN[10].ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
