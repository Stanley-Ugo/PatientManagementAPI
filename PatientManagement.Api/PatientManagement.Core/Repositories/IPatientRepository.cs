using PatientManagement.Core.Entities;

namespace PatientManagement.Core.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int id);
        Task<List<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}
