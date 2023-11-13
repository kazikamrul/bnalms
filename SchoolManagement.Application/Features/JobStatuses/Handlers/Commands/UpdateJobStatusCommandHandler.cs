using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.JobStatuses.Requests.Commands;
using SchoolManagement.Application.DTOs.JobStatus.Validators;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Commands
{
    public class UpdateJobStatusCommandHandler : IRequestHandler<UpdateJobStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateJobStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateJobStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateJobStatusDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.JobStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var JobStatus = await _unitOfWork.Repository<JobStatus>().Get(request.JobStatusDto.JobStatusId);

            if (JobStatus is null)
                throw new NotFoundException(nameof(JobStatus), request.JobStatusDto.JobStatusId);

            _mapper.Map(request.JobStatusDto, JobStatus);

            await _unitOfWork.Repository<JobStatus>().Update(JobStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
