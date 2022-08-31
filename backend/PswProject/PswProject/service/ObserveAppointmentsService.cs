﻿using PswProject.model;
using PswProject.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PswProject.service
{
    public class ObserveAppointmentsService
    {
        private MyDbContext dbContext { get; set; }
        private ObserveAppointmentsSqlRepository ObserveAppointmentsSqlRepository;
        private AppointmentRepository AppointmentRepository { get; set; }
        private Appointment Appointment = new Appointment();

        public ObserveAppointmentsService(ObserveAppointmentsSqlRepository observeAppointmentsSqlRepository)
        {
            this.ObserveAppointmentsSqlRepository = observeAppointmentsSqlRepository;
            AppointmentRepository = observeAppointmentsSqlRepository;
        }

        public ObserveAppointmentsService(AppointmentRepository iAppointmentRepository)
        {
            AppointmentRepository = iAppointmentRepository;
        }

        public List<Appointment> GetAppointmentsById(int id)
        {
            List<Appointment> appointments = ObserveAppointmentsSqlRepository.GetById(id);

            return Appointment.StatusAppointment(appointments);
        }
        public List<Appointment> GetDoctorsAppointmentsById(int id)
        {
            List<Appointment> appointments = ObserveAppointmentsSqlRepository.GetDoctorsApById(id);

            return Appointment.StatusAppointment(appointments);
        }

        //CancelAppointments
        public bool CancelAppointment(int appointmentId)
        {
            Appointment appointment = AppointmentRepository.GetByAppointmentId(appointmentId);
            ObserveAppointmentsSqlRepository.GetUserByApId(appointment);
            //appointment.isCancelled = true;
            //appointment.canCancel = false;
            bool retVal = AppointmentRepository.Update(appointment);
            return retVal;
        }
    }
}