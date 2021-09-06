using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Computer : DBOject
    {
        public string IPAddress { get; set; }
        public string MACAddress { get; set; }
        public string DomainName { get; set; }
        public string INumber { get; set; }
        public int GroupID { get; set; }
    }
}
