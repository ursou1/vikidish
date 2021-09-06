using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    class ComputerManager : Manager<Computer>
    {
        public ComputerManager(IDB<Computer> iDBComputer):base(iDBComputer)
        {
            

        }

        public Computer CreateNewComputer()
        {
            Computer comparer = db.Create();
            array.Add(comparer);
            return comparer;
        }

        public List<Computer> GetComparersByGroup(GroupComputer group)
        {
            return array.Where(s => s.GroupID == group.ID).ToList();
        }

        
    }
}
