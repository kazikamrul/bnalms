﻿using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetBulletinDetailRequestHandler : IRequestHandler<GetBulletinDetailRequest, BulletinDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Bulletin> _BulletinRepository;
        public GetBulletinDetailRequestHandler(ISchoolManagementRepository<Bulletin> BulletinRepository, IMapper mapper)
        {
            _BulletinRepository = BulletinRepository;
            _mapper = mapper;
        }
        public async Task<BulletinDto> Handle(GetBulletinDetailRequest request, CancellationToken cancellationToken)
        {
            var Bulletin = await _BulletinRepository.Get(request.BulletinId);
            return _mapper.Map<BulletinDto>(Bulletin);
        }
    }
}
