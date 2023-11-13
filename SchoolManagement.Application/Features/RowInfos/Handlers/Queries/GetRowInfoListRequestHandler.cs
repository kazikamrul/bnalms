using SchoolManagement.Application.Features.RowInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RowInfos.Handlers.Queries
{
    public class GetRowInfoListRequestHandler : IRequestHandler<GetRowInfoListRequest, PagedResult<RowInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RowInfo> _RowInfoRepository;

        private readonly IMapper _mapper;

        public GetRowInfoListRequestHandler(ISchoolManagementRepository<RowInfo> RowInfoRepository, IMapper mapper)
        {
            _RowInfoRepository = RowInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RowInfoDto>> Handle(GetRowInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<RowInfo> RowInfos = _RowInfoRepository.FilterWithInclude(x => (x.RowName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "ShelfInfo");
            var totalCount = RowInfos.Count();
            RowInfos = RowInfos.OrderByDescending(x => x.RowInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RowInfoDtos = _mapper.Map<List<RowInfoDto>>(RowInfos);
            var result = new PagedResult<RowInfoDto>(RowInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
