using SchoolManagement.Application.Features.Sources.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Sources.Handlers.Queries
{
    public class GetSourceListRequestHandler : IRequestHandler<GetSourceListRequest, PagedResult<SourceDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Source> _SourceRepository;

        private readonly IMapper _mapper;

        public GetSourceListRequestHandler(ISchoolManagementRepository<Source> SourceRepository, IMapper mapper)
        {
            _SourceRepository = SourceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SourceDto>> Handle(GetSourceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Source> Sources = _SourceRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Sources.Count();
            Sources = Sources.OrderByDescending(x => x.SourceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var SourceDtos = _mapper.Map<List<SourceDto>>(Sources);
            var result = new PagedResult<SourceDto>(SourceDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
