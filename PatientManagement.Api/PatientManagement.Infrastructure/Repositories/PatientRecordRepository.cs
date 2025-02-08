using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Repositories;
using PatientManagement.Infrastructure.DatabaseContext;

namespace PatientManagement.Infrastructure.Repositories
{
    public class PatientRecordRepository : IPatientRecordRepository
    {
        private readonly PatientContext _context;
        public PatientRecordRepository(PatientContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PatientRecord record)
        {
            _context.PatientRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PatientRecord>> GetByPatientIdAsync(int patientId)
        {
            return await _context.PatientRecords.Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task UpdateAsync(PatientRecord record)
        {
            _context.PatientRecords.Update(record);
            await _context.SaveChangesAsync();
        }
    }
}
