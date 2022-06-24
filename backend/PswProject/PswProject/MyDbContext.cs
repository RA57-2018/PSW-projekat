using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PswProject.model;

namespace PswProject
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(mb =>
            {
                mb.HasData(
                new User(1, "Marko", "Markovic", "miki98", "miki985@", "0641664608", "3009998805138", Role.PATIENT,
                "Bulevar Oslobodjenja 8", Gender.MALE, false),
                new User(2, "Milica", "Mikic", "mici97", "mici789@", "0652459871", "3009998805137", Role.PATIENT,
                "Kisacka 5", Gender.FEMALE, false)
                );

            });

            modelBuilder.Entity<Doctor>()
                .HasData(
                new Doctor(1, "Milan", "Popovic", Specialization.GENERAL),
                new Doctor(2, "Milana", "Pilipovic", Specialization.CARDIOLOGIST)
                );


        }
    }
}
