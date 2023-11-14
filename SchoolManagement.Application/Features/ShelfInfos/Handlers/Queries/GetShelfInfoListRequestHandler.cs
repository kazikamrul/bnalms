using SchoolManagement.Application.Features.ShelfInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ShelfInfos.Handlers.Queries
{
    public class GetShelfInfoListRequestHandler : IRequestHandler<GetShelfInfoListRequest, PagedResult<ShelfInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ShelfInfo> _ShelfInfoRepository;

        private readonly IMapper _mapper;

        public GetShelfInfoListRequestHandler(ISchoolManagementRepository<ShelfInfo> ShelfInfoRepository, IMapper mapper)
        {
            _ShelfInfoRepository = ShelfInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ShelfInfoDto>> Handle(GetShelfInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ShelfInfo> ShelfInfos = _ShelfInfoRepository.FilterWithInclude(x => (x.ShelfName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ShelfInfos.Count();
            ShelfInfos = ShelfInfos.OrderByDescending(x => x.ShelfInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ShelfInfoDtos = _mapper.Map<List<ShelfInfoDto>>(ShelfInfos);
            var result = new PagedResult<ShelfInfoDto>(ShelfInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
