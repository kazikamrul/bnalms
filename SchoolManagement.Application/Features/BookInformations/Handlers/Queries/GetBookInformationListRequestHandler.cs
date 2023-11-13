using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetBookInformationListRequestHandler : IRequestHandler<GetBookInformationListRequest, PagedResult<BookInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BookInformation> _BookInformationRepository;

        private readonly IMapper _mapper;

        public GetBookInformationListRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository, IMapper mapper)
        {
            _BookInformationRepository = BookInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookInformationDto>> Handle(GetBookInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BookInformation> BookInformations = _BookInformationRepository.FilterWithInclude(x => (x.AccessionNo.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookCategory", "BookTitleInfo", "MainClass");
            var totalCount = BookInformations.Count();
            BookInformations = BookInformations.OrderByDescending(x => x.BookInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BookInformationDtos = _mapper.Map<List<BookInformationDto>>(BookInformations);
            var result = new PagedResult<BookInformationDto>(BookInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
