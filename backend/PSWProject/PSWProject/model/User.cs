using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSWProject.model
{
    public class User
    {
        private String name;
        private String surname;
        private String jmbg;
        private String phoneNumber;
        private String type;
        private String username;
        private String password;
        private String address;
        private DateTime birthdayDate;

        public User() { }

        public User(String name, String surname, String jmbg, String phoneNumber, String type, String username, String password, String address,
            DateTime birthdayDate) 
        {
            this.name = name;
            this.surname = surname;
            this.jmbg = jmbg;
            this.phoneNumber = phoneNumber;
            this.type = type;
            this.username = username;
            this.password = password;
            this.address = address;
            this.birthdayDate = birthdayDate;
        }
        /*
        public String getName() 
        {
            return name;
        }

        public void setName(String name) 
        {
            this.name = name;
        }

        public String getSurname()
        {
            return surname;
        }

        public void setSurname(String surname)
        {
            this.surname = surname;
        }

        public String getJmbg()
        {
            return jmbg;
        }

        public void setJmbg(String jmbg)
        {
            this.jmbg = jmbg;
        }

        public int getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setPhoneNumber(int phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public String getType()
        {
            return type;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public String getUsername()
        {
            return username;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getPassword()
        {
            return password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getAddress()
        {
            return address;
        }

        public void setAddress(String address)
        {
            this.address = address;
        }

        public DateTime getBirthdayDate()
        {
            return birthdayDate;
        }

        public void setBirthdayDate(DateTime birthdayDate)
        {
            this.birthdayDate = birthdayDate;
        }*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnProperychanged("Name");
                }
            }
        }

        public String Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (value != surname)
                {
                    surname = value;
                    OnProperychanged("Surname");
                }
            }
        }

        public String Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnProperychanged("Jmbg");
                }
            }
        }

        public String PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnProperychanged("PhoneNumber");
                }
            }
        }

        public DateTime BirthdayDate
        {
            get
            {
                return birthdayDate;
            }
            set
            {
                if (value != birthdayDate)
                {
                    birthdayDate = value;
                    OnProperychanged("BirthdayDate");
                }
            }
        }

        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                if (value != username)
                {
                    username = value;
                    OnProperychanged("Username");
                }
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                if (value != password)
                {
                    password = value;
                    OnProperychanged("Password");
                }
            }
        }
        public String Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value != address)
                {
                    address = value;
                    OnProperychanged("Address");
                }
            }
        }

        public String Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnProperychanged("Type");
                }
            }
        }
    }
}
