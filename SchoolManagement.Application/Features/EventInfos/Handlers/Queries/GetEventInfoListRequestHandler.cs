using SchoolManagement.Application.Features.EventInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.EventInfos.Handlers.Queries
{
    public class GetEventInfoListRequestHandler : IRequestHandler<GetEventInfoListRequest, PagedResult<EventInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EventInfo> _EventInfoRepository;

        private readonly IMapper _mapper;

        public GetEventInfoListRequestHandler(ISchoolManagementRepository<EventInfo> EventInfoRepository, IMapper mapper)
        {
            _EventInfoRepository = EventInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<EventInfoDto>> Handle(GetEventInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<EventInfo> EventInfos = _EventInfoRepository.FilterWithInclude(x => (x.EventName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = EventInfos.Count();
            EventInfos = EventInfos.OrderByDescending(x => x.EventInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var EventInfoDtos = _mapper.Map<List<EventInfoDto>>(EventInfos);
            var result = new PagedResult<EventInfoDto>(EventInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
