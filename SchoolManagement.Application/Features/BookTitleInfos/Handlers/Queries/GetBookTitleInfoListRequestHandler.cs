using SchoolManagement.Application.Features.BookTitleInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookTitleInfos.Handlers.Queries
{
    public class GetBookTitleInfoListRequestHandler : IRequestHandler<GetBookTitleInfoListRequest, PagedResult<BookTitleInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BookTitleInfo> _BookTitleInfoRepository;

        private readonly IMapper _mapper;

        public GetBookTitleInfoListRequestHandler(ISchoolManagementRepository<BookTitleInfo> BookTitleInfoRepository, IMapper mapper)
        {
            _BookTitleInfoRepository = BookTitleInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookTitleInfoDto>> Handle(GetBookTitleInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BookTitleInfo> BookTitleInfos = _BookTitleInfoRepository.FilterWithInclude(x => (x.BookTitleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BookTitleInfos.Count();
            BookTitleInfos = BookTitleInfos.OrderByDescending(x => x.BookTitleInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BookTitleInfoDtos = _mapper.Map<List<BookTitleInfoDto>>(BookTitleInfos);
            var result = new PagedResult<BookTitleInfoDto>(BookTitleInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
