using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
   public interface IConvertModel<T>
    {
        T ConvertModel();
    }
}
