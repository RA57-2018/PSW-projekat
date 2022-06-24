using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.model
{
    public class Doctor
    {
        public int IdD { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public Specialization Specialization { get; set; }

        public Doctor() { }

        public Doctor(int id, string name, string surname, Specialization specialization)
        {
            this.IdD = id;
            this.Name = name;
            this.Surname = surname;
            this.Specialization = specialization;
        }
    }
}
