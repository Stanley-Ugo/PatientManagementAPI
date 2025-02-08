using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;

namespace PatientManagement.Infrastructure.DatabaseContext
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=patients.db");
        }
    }
}
