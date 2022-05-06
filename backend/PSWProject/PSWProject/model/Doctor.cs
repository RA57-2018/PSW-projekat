using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSWProject.model
{
    public class Doctor : User
    {
        private String specialisation;
        private Boolean specialist;
        private int freeDays;
        private Examination examination;
    }
}
