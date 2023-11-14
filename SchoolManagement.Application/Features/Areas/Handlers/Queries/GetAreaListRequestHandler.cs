using SchoolManagement.Application.Features.Areas.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Areas.Handlers.Queries
{
    public class GetAreaListRequestHandler : IRequestHandler<GetAreaListRequest, PagedResult<AreaDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Area> _AreaRepository;

        private readonly IMapper _mapper;

        public GetAreaListRequestHandler(ISchoolManagementRepository<Area> AreaRepository, IMapper mapper)
        {
            _AreaRepository = AreaRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AreaDto>> Handle(GetAreaListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Area> Areas = _AreaRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Areas.Count();
            Areas = Areas.OrderByDescending(x => x.AreaId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var AreaDtos = _mapper.Map<List<AreaDto>>(Areas);
            var result = new PagedResult<AreaDto>(AreaDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
