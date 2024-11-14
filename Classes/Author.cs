using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_4.Classes
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public Author() { }
        public Author(string _FirstName, string _LastName)
        {
            FirstName = _FirstName;
            LastName = _LastName;

            Name = FirstName + " " + LastName;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
