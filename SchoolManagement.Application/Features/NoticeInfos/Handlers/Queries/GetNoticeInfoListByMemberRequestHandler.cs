using SchoolManagement.Application.Features.NoticeInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NoticeInfos.Handlers.Queries
{
    public class GetNoticeInfoListByMemberRequestHandler : IRequestHandler<GetNoticeInfoListByMemberRequest, PagedResult<NoticeInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NoticeInfo> _NoticeInfoRepository;

        private readonly IMapper _mapper;

        public GetNoticeInfoListByMemberRequestHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository, IMapper mapper)
        {
            _NoticeInfoRepository = NoticeInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NoticeInfoDto>> Handle(GetNoticeInfoListByMemberRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<NoticeInfo> NoticeInfos = _NoticeInfoRepository.FilterWithInclude(x => (x.NoticeTitle.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText) && x.MemberInfoId == request.MemberInfoId), "NoticeType");
            var totalCount = NoticeInfos.Count();
            NoticeInfos = NoticeInfos.OrderByDescending(x => x.NoticeInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NoticeInfoDtos = _mapper.Map<List<NoticeInfoDto>>(NoticeInfos);
            var result = new PagedResult<NoticeInfoDto>(NoticeInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
