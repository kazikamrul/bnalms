using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Commands
{
    public class DeleteDamageInformationByLibraryCommandHandler : IRequestHandler<DeleteDamageInformationByLibraryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDamageInformationByLibraryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDamageInformationByLibraryCommand request, CancellationToken cancellationToken)
        {
            var DamageInformationByLibrary = await _unitOfWork.Repository<DamageInformationByLibrary>().Get(request.DamageInformationByLibraryId);

            if (DamageInformationByLibrary == null)
                throw new NotFoundException(nameof(DamageInformationByLibrary), request.DamageInformationByLibraryId);

            await _unitOfWork.Repository<DamageInformationByLibrary>().Delete(DamageInformationByLibrary);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
