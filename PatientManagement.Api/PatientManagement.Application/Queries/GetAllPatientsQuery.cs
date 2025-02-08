using MediatR;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Repositories;

namespace PatientManagement.Application.Queries
{
    public class GetAllPatientsQuery : IRequest<List<Patient>> { }

    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, List<Patient>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<Patient>> Handle(GetAllPatientsQuery request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetAllAsync();
        }
    }
}
