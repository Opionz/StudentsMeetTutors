using Microsoft.EntityFrameworkCore;
using StudentsMeetTutors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsMeetTutors.Data
{
    public class StudentsMeetTutorsContext : DbContext
    {
        public StudentsMeetTutorsContext() : base()
        {

        }

        public DbSet<StudentRecord> Students { get; set; }
        public DbSet<TutorRecord> Tutors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            "Data Source= (localdb)\\MSSQLLocalDB;Initial Catalog=StudentsMeetTutors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
