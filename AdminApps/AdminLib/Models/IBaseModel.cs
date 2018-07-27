using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Models
{
   public interface IBaseModel<T>
    {
        Task<List<T>> Get();
        Task<T> GetById();
        Task<T> SaveChange();
        Task<bool> Delete();
      
    }
}
