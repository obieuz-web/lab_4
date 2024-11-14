using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4.Classes
{
    public class Publisher
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Publisher() { }
        public Publisher(string _Name)
        {
            Name = _Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
