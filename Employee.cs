using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5
{
    internal class Employee
    {
       public int Id { get; set; }
       public string? Name { get; set; }
       public string ? Surname { get; set; }
       public int? Rang { get; set; }
       public Employee(int id, string? name, string? surname, int? rang)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Rang = rang;
        }
        public Employee()
        {
            Id = 0;
            Name = null;
            Surname = null;
            Rang = null;
        }
    }
}
