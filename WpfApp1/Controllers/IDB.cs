using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Controllers
{
   public interface IDB<T>
    {
        IEnumerable<T> GetAll();
        T Create();
        void Update(T obj);
        void Delete(T obj);
    }
}
