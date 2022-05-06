using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSWProject.model
{
    public class Patient : User
    {
        private int idHealthCard;
        private String occupation;
        private Boolean blocked = false;
        private Examination examination;

        public Patient() { }

        public Patient(String name, String surname, int idHealthCard, String occupation, Boolean blocked)
        {
            name = name;
            surname = surname;
            this.idHealthCard = idHealthCard;
            this.occupation = occupation;
            this.blocked = blocked;
        }

        public int IdHealthCard
        {
            get
            {
                return idHealthCard;
            }
            set
            {
                if (value != idHealthCard)
                {
                    idHealthCard = value;

                }
            }
        }

        public String Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                if (value != occupation)
                {
                    occupation = value;

                }
            }
        }

        public Boolean Blocked
        {
            get
            {
                return blocked;
            }
            set
            {
                if (value != blocked)
                {
                    blocked = value;

                }
            }
        }

    }
}
