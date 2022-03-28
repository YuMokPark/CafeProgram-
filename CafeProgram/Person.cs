using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeProgram
{
    internal class Person
    {
        string name;
        string birth;
        string tell;

        public Person() { }
        public Person(string name, string birth, string tell)
        {

            this.name = name;
            this.birth = birth;
            this.tell = tell;
        }
        public string Name { get { return name; } }
        public string Birth { get { return birth; } }
        public string Tell { get { return tell; } }
    }
}
