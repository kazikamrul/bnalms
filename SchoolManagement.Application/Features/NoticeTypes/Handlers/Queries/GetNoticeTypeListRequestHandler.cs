using SchoolManagement.Application.Features.NoticeTypes.Requests.Queries;
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
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NoticeTypes.Handlers.Queries
{
    public class GetNoticeTypeListRequestHandler : IRequestHandler<GetNoticeTypeListRequest, PagedResult<NoticeTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NoticeType> _NoticeTypeRepository;

        private readonly IMapper _mapper;

        public GetNoticeTypeListRequestHandler(ISchoolManagementRepository<NoticeType> NoticeTypeRepository, IMapper mapper)
        {
            _NoticeTypeRepository = NoticeTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NoticeTypeDto>> Handle(GetNoticeTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<NoticeType> NoticeTypes = _NoticeTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = NoticeTypes.Count();
            NoticeTypes = NoticeTypes.OrderByDescending(x => x.NoticeTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var NoticeTypeDtos = _mapper.Map<List<NoticeTypeDto>>(NoticeTypes);
            var result = new PagedResult<NoticeTypeDto>(NoticeTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
