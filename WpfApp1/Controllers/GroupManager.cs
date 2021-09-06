using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Controllers
{
    public class GroupManager : Manager<GroupComputer>
    {
        

        public GroupManager(IDB<GroupComputer> iDBGroup): base(iDBGroup)
        {
            
        }

        public GroupComputer CreateNewGroup(string name)
        {
            GroupComputer group = db.Create();
            group.Name = name;
            array.Add(group);
            return group;
        }

        public List<GroupComputer> GetAllGroups() => 
            array;

        public GroupComputer SelectGroupByID(int groupId)//получить группу с её айди
        {
            GroupComputer group = array.
                FirstOrDefault(g => g.ID == groupId);
            if (group == null)
                group = new GroupComputer {
                    Name = "Группа не найдена" };
            return group;
        }

        
    }
}
