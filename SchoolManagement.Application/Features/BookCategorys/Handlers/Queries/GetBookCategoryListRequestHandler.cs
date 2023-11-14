using SchoolManagement.Application.Features.BookCategorys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Queries
{
    public class GetBookCategoryListRequestHandler : IRequestHandler<GetBookCategoryListRequest, PagedResult<BookCategoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BookCategory> _BookCategoryRepository;

        private readonly IMapper _mapper;

        public GetBookCategoryListRequestHandler(ISchoolManagementRepository<BookCategory> BookCategoryRepository, IMapper mapper)
        {
            _BookCategoryRepository = BookCategoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookCategoryDto>> Handle(GetBookCategoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BookCategory> BookCategorys = _BookCategoryRepository.FilterWithInclude(x => (x.BookCategoryName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BookCategorys.Count();
            BookCategorys = BookCategorys.OrderByDescending(x => x.BookCategoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BookCategoryDtos = _mapper.Map<List<BookCategoryDto>>(BookCategorys);
            var result = new PagedResult<BookCategoryDto>(BookCategoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
