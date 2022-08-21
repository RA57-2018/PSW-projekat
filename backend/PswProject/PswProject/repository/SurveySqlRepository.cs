using PswProject.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PswProject.repository
{
    public class SurveySqlRepository : SurveyRepository
    {
        public MyDbContext dbContext { get; set; }
        private int idS { get; set; }

        public SurveySqlRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public SurveySqlRepository()
        {

        }

        public bool CheckIfExistsById(int id)
        {
            foreach (Survey s in GetAll())
            {
                if (s.AppointmentId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Survey> GetAll()
        {
            List<Survey> result = new List<Survey>();

            dbContext.Survey.ToList().ForEach(survey => result.Add(new Survey(survey.Id, survey.PatientId, survey.Date, survey.AppointmentId)));

            return result;
        }

        public Survey GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Survey newObject)
        {
            throw new NotImplementedException();
        }

        public bool Update(Survey editedObject)
        {
            throw new NotImplementedException();
        }

        public void CreateSurvey(List<AnsweredQuestion> answeredQuestion, string id, string ap)
        {
            idS = GetAll().Count + 1;
            dbContext.Survey.Add(new Survey(idS, Int32.Parse(id), DateTime.Now, Int32.Parse(ap)));
            Console.WriteLine((idS, Int32.Parse(id), DateTime.Now, Int32.Parse(ap)));
            dbContext.SaveChanges();
            ChangeAppointment(ap);

            //var a = dbContext.Survey.Max(s => s.Id);

            //foreach (AnsweredQuestion answer in answeredQuestion)
            //{
            //    answer.SurveyId = a;
            //    dbContext.AnsweredQuestion.Add(answer);
            //}

            dbContext.SaveChanges();
        }

        private void ChangeAppointment(string ap)
        {
            Survey sur = dbContext.Survey.Where(s => s.AppointmentId == Int32.Parse(ap)).FirstOrDefault();
            Appointment app = dbContext.Appointments.Where(s => s.IdA == sur.AppointmentId).FirstOrDefault();
            dbContext.Remove(app);
            dbContext.SaveChanges();
            app.SurveyId = sur.Id;
            dbContext.Appointments.Add(app);
            dbContext.SaveChanges();
        }

        public void CreateSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
