using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PswProject.model
{
    public class Appointment : INotifyPropertyChanged
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdA { get; set; }
        public String StartTime { get; set; }
        public int DurationInMinutes { get; private set; }
        public String ApointmentDescription { get; private set; }
        public int UserId { get; private set; }
        public virtual User User { get; private set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public AppointmentStatus Status { get; set; }
        public int SurveyId { get; set; }
        public Boolean isCancelled { get; private set; }
        public Boolean canCancel { get; private set; }
        public Boolean IsDeleted { get; private set; }

        public Appointment() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public String EndTime
        {
            get
            {
                return StartTime;
            }
        }

        public String BeginTime
        {
            get
            {
                return StartTime;
            }
        }

        public String UserName
        {
            get
            {
                if (User != null)
                    return (User.Name + " " + User.Surname);
                else
                    return "";
            }
        }

        public String DoctorName
        {
            get
            {
                if (Doctor != null)
                    return (Doctor.Name + " " + Doctor.Surname);
                else
                    return "";
            }
            set
            {
                OnPropertyChanged("DoctorName");
            }
        }
    }
}
