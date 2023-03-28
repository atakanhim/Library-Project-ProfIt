using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface ItcknValidator
    {
        bool Validate(string tckno);
    }
}
