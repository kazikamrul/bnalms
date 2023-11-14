using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.JobStatus.Validators;
using SchoolManagement.Application.Features.JobStatuses.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Commands
{
    public class CreateJobStatusCommandHandler : IRequestHandler<CreateJobStatusCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateJobStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateJobStatusCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateJobStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.JobStatusDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var JobStatus = _mapper.Map<JobStatus>(request.JobStatusDto);

                JobStatus = await _unitOfWork.Repository<JobStatus>().Add(JobStatus);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = JobStatus.JobStatusId;
            }

            return response;
        }
    }
}
