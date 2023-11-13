using SchoolManagement.Application.Features.FeeInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FeeInformations.Handlers.Queries
{
    public class GetFeeInformationListRequestHandler : IRequestHandler<GetFeeInformationListRequest, PagedResult<FeeInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FeeInformation> _FeeInformationRepository;

        private readonly IMapper _mapper;

        public GetFeeInformationListRequestHandler(ISchoolManagementRepository<FeeInformation> FeeInformationRepository, IMapper mapper)
        {
            _FeeInformationRepository = FeeInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FeeInformationDto>> Handle(GetFeeInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<FeeInformation> FeeInformations = _FeeInformationRepository.FilterWithInclude(x => (x.MemberInfo.PNO.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "MemberInfo", "FeeCategory");
            var totalCount = FeeInformations.Count();
            FeeInformations = FeeInformations.OrderByDescending(x => x.FeeInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var FeeInformationDtos = _mapper.Map<List<FeeInformationDto>>(FeeInformations);
            var result = new PagedResult<FeeInformationDto>(FeeInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
