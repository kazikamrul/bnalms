using SchoolManagement.Application.Features.Designations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Designation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Designations.Handlers.Queries
{
    public class GetDesignationListRequestHandler : IRequestHandler<GetDesignationListRequest, PagedResult<DesignationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Designation> _DesignationRepository;

        private readonly IMapper _mapper;

        public GetDesignationListRequestHandler(ISchoolManagementRepository<Designation> DesignationRepository, IMapper mapper)
        {
            _DesignationRepository = DesignationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DesignationDto>> Handle(GetDesignationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Designation> Designations = _DesignationRepository.FilterWithInclude(x => (x.DesignationName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Designations.Count();
            Designations = Designations.OrderByDescending(x => x.DesignationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DesignationDtos = _mapper.Map<List<DesignationDto>>(Designations);
            var result = new PagedResult<DesignationDto>(DesignationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
