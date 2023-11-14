using SchoolManagement.Application.Features.BookBindingInfos.Requests.Queries;
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
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookBindingInfos.Handlers.Queries
{
    public class GetBookBindingInfoListRequestHandler : IRequestHandler<GetBookBindingInfoListRequest, PagedResult<BookBindingInfoDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BookBindingInfo> _BookBindingInfoRepository;

        private readonly IMapper _mapper;

        public GetBookBindingInfoListRequestHandler(ISchoolManagementRepository<BookBindingInfo> BookBindingInfoRepository, IMapper mapper)
        {
            _BookBindingInfoRepository = BookBindingInfoRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookBindingInfoDto>> Handle(GetBookBindingInfoListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BookBindingInfo> BookBindingInfos = _BookBindingInfoRepository.FilterWithInclude(x => (x.PressName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookInformation", "BookInformation.BookCategory", "BookInformation.BookTitleInfo");
            var totalCount = BookBindingInfos.Count();
            BookBindingInfos = BookBindingInfos.OrderByDescending(x => x.BookBindingInfoId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BookBindingInfoDtos = _mapper.Map<List<BookBindingInfoDto>>(BookBindingInfos);
            var result = new PagedResult<BookBindingInfoDto>(BookBindingInfoDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
