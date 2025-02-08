using MediatR;
using PatientManagement.Core.Entities;
using PatientManagement.Core.Repositories;

namespace PatientManagement.Application.Queries
{
    public class GetPatientByIdQuery : IRequest<Patient>
    {
        public int Id { get; set; }
    }

    public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _patientRepository.GetByIdAsync(request.Id);
        }
    }
}
