using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Repositories;
using PatientManagement.Infrastructure.DatabaseContext;

namespace PatientManagement.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly PatientContext _context;

        public PatientRepository(PatientContext context)
        {
            _context = context;
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                patient.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
