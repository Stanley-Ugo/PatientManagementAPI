using PatientManagement.Core.Entities;

namespace PatientManagement.Core.Repositories
{
    public interface IPatientRecordRepository
    {
        Task<List<PatientRecord>> GetByPatientIdAsync(int patientId);
        Task AddAsync(PatientRecord record);
        Task UpdateAsync(PatientRecord record);
    }
}
