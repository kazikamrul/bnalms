using SchoolManagement.Application.Features.SupplierInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SupplierInformations.Handlers.Queries
{
    public class GetSupplierInformationListRequestHandler : IRequestHandler<GetSupplierInformationListRequest, PagedResult<SupplierInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SupplierInformation> _SupplierInformationRepository;

        private readonly IMapper _mapper;

        public GetSupplierInformationListRequestHandler(ISchoolManagementRepository<SupplierInformation> SupplierInformationRepository, IMapper mapper)
        {
            _SupplierInformationRepository = SupplierInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SupplierInformationDto>> Handle(GetSupplierInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SupplierInformation> SupplierInformations = _SupplierInformationRepository.FilterWithInclude(x => (x.SupplierName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookInformation.BookTitleInfo");
            var totalCount = SupplierInformations.Count();
            SupplierInformations = SupplierInformations.OrderByDescending(x => x.SupplierInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BookInformationId == request.BookInformationId);

            var SupplierInformationDtos = _mapper.Map<List<SupplierInformationDto>>(SupplierInformations);
            var result = new PagedResult<SupplierInformationDto>(SupplierInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
