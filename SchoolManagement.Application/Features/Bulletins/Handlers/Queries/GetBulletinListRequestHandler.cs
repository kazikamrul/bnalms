using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetBulletinListRequestHandler : IRequestHandler<GetBulletinListRequest, PagedResult<BulletinDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Bulletin> _BulletinRepository;

        private readonly IMapper _mapper;

        public GetBulletinListRequestHandler(ISchoolManagementRepository<Bulletin> BulletinRepository, IMapper mapper)
        {
            _BulletinRepository = BulletinRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BulletinDto>> Handle(GetBulletinListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Bulletin> Bulletins = _BulletinRepository.FilterWithInclude(x => (x.BuletinDetails.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName");
            var totalCount = Bulletins.Count();
            Bulletins = Bulletins.OrderByDescending(x => x.BulletinId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BulletinDtos = _mapper.Map<List<BulletinDto>>(Bulletins);
            var result = new PagedResult<BulletinDto>(BulletinDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
