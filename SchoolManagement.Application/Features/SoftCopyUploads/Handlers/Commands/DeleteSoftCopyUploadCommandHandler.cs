using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Commands
{
    public class DeleteSoftCopyUploadCommandHandler : IRequestHandler<DeleteSoftCopyUploadCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var SoftCopyUpload = await _unitOfWork.Repository<SoftCopyUpload>().Get(request.SoftCopyUploadId);

            if (SoftCopyUpload == null)
                throw new NotFoundException(nameof(SoftCopyUpload), request.SoftCopyUploadId);

            await _unitOfWork.Repository<SoftCopyUpload>().Delete(SoftCopyUpload);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
