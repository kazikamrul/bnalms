using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.JobStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Commands
{
    public class DeleteJobStatusCommandHandler : IRequestHandler<DeleteJobStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteJobStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteJobStatusCommand request, CancellationToken cancellationToken)
        {
            var JobStatus = await _unitOfWork.Repository<JobStatus>().Get(request.JobStatusId);

            if (JobStatus == null)
                throw new NotFoundException(nameof(JobStatus), request.JobStatusId);

            await _unitOfWork.Repository<JobStatus>().Delete(JobStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
