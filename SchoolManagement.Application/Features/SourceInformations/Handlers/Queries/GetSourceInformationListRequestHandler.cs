using SchoolManagement.Application.Features.SourceInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SourceInformations.Handlers.Queries
{
    public class GetSourceInformationListRequestHandler : IRequestHandler<GetSourceInformationListRequest, PagedResult<SourceInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SourceInformation> _SourceInformationRepository;

        private readonly IMapper _mapper;

        public GetSourceInformationListRequestHandler(ISchoolManagementRepository<SourceInformation> SourceInformationRepository, IMapper mapper)
        {
            _SourceInformationRepository = SourceInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SourceInformationDto>> Handle(GetSourceInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SourceInformation> SourceInformations = _SourceInformationRepository.FilterWithInclude(x => (x.SourceName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookInformation.BookTitleInfo");
            var totalCount = SourceInformations.Count();
            SourceInformations = SourceInformations.OrderByDescending(x => x.SourceInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BookInformationId == request.BookInformationId);

            var SourceInformationDtos = _mapper.Map<List<SourceInformationDto>>(SourceInformations);
            var result = new PagedResult<SourceInformationDto>(SourceInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
