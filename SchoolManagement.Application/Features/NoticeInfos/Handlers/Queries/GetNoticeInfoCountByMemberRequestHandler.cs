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
    public class GetNoticeInfoCountByMemberRequestHandler : IRequestHandler<GetNoticeInfoCountByMemberRequest, List<NoticeInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NoticeInfo> _NoticeInfoRepository;

        private readonly IMapper _mapper;

        public GetNoticeInfoCountByMemberRequestHandler(ISchoolManagementRepository<NoticeInfo> NoticeInfoRepository, IMapper mapper)
        {
            _NoticeInfoRepository = NoticeInfoRepository;
            _mapper = mapper;
        }

        public async Task<List<NoticeInfoDto>> Handle(GetNoticeInfoCountByMemberRequest request, CancellationToken cancellationToken)
        {
            
            IQueryable<NoticeInfo> noticeList =  _NoticeInfoRepository.FilterWithInclude(x=> x.MemberInfoId == request.MemberInfoId && x.ViewStatus == 0);

            var noticeListDtos = _mapper.Map<List<NoticeInfoDto>>(noticeList);
            return noticeListDtos;


        }
    }
}
