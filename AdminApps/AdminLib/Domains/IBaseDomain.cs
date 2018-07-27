using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminLib.Domains
{
    public interface IBaseDomain<T>
    {
        Task<List<T>> Get();
        Task<T> GetById(int id);
        Task<T> SaveChange(T item);
        Task<bool> Delete(int id);
    }
}
