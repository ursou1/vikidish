using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Controllers
{
    public abstract class Manager<T>
    {
        protected IDB<T> db;
        protected List<T> array = new List<T>();
        protected Manager(IDB<T> db)
        {
            this.db = db;
            array.AddRange(db.GetAll());
        }
        public void Update(T obj)
        {
            db.Update(obj);
        }

        public void Delete(T obj)
        {
            array.Remove(obj);
            db.Delete(obj);
        }
    }
}
