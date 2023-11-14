using SchoolManagement.Application.Features.MemberInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MemberInfos.Handlers.Queries
{
    public class GetMemberInfoListRequestHandler : IRequestHandler<GetMemberInfoListRequest, PagedResult<MemberInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MemberInfo> _MemberInfoRepository;

        private readonly IMapper _mapper;

        public GetMemberInfoListRequestHandler(ISchoolManagementRepository<MemberInfo> MemberInfoRepository, IMapper mapper)
        {
            _MemberInfoRepository = MemberInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MemberInfoDto>> Handle(GetMemberInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MemberInfo> MemberInfos = _MemberInfoRepository.FilterWithInclude(x => (x.MemberName.Contains(request.QueryParams.SearchText)|| x.PNO.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "Rank");
            var totalCount = MemberInfos.Count();
            MemberInfos = MemberInfos.OrderByDescending(x => x.MemberInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MemberInfoDtos = _mapper.Map<List<MemberInfoDto>>(MemberInfos);
            var result = new PagedResult<MemberInfoDto>(MemberInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
