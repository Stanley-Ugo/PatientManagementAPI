using MediatR;
using PatientManagement.Core.Repositories;

namespace PatientManagement.Application.Commands
{
    public class SoftDeletePatientCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class SoftDeletePatientCommandHandler : IRequestHandler<SoftDeletePatientCommand>
    {
        private readonly IPatientRepository _patientRepository;

        public SoftDeletePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task Handle(SoftDeletePatientCommand request, CancellationToken cancellationToken)
        {
            await _patientRepository.DeleteAsync(request.Id);
        }
    }
}
