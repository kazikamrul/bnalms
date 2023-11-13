using SchoolManagement.Application.Features.DemandBooks.Requests.Queries;
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
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandBooks.Handlers.Queries
{
    public class GetDemandBookListRequestHandler : IRequestHandler<GetDemandBookListRequest, PagedResult<DemandBookDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DemandBook> _DemandBookRepository;

        private readonly IMapper _mapper;

        public GetDemandBookListRequestHandler(ISchoolManagementRepository<DemandBook> DemandBookRepository, IMapper mapper)
        {
            _DemandBookRepository = DemandBookRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DemandBookDto>> Handle(GetDemandBookListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<DemandBook> DemandBooks = _DemandBookRepository.FilterWithInclude(x => (x.BookName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = DemandBooks.Count();
            DemandBooks = DemandBooks.OrderByDescending(x => x.DemandBookId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DemandBookDtos = _mapper.Map<List<DemandBookDto>>(DemandBooks);
            var result = new PagedResult<DemandBookDto>(DemandBookDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
