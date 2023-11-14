using SchoolManagement.Application.Features.Bases.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Bases.Handlers.Queries
{
    public class GetBaseListRequestHandler : IRequestHandler<GetBaseListRequest, PagedResult<BasemDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Base> _BaseRepository;

        private readonly IMapper _mapper;

        public GetBaseListRequestHandler(ISchoolManagementRepository<Base> BaseRepository, IMapper mapper)
        {
            _BaseRepository = BaseRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BasemDto>> Handle(GetBaseListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Base> Bases = _BaseRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Bases.Count();
            Bases = Bases.OrderByDescending(x => x.BaseId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BaseDtos = _mapper.Map<List<BasemDto>>(Bases);
            var result = new PagedResult<BasemDto>(BaseDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
