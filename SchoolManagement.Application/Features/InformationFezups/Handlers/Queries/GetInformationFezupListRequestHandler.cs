using SchoolManagement.Application.Features.InformationFezups.Requests.Queries;
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
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InformationFezups.Handlers.Queries
{
    public class GetInformationFezupListRequestHandler : IRequestHandler<GetInformationFezupListRequest, PagedResult<InformationFezupDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InformationFezup> _InformationFezupRepository;

        private readonly IMapper _mapper;

        public GetInformationFezupListRequestHandler(ISchoolManagementRepository<InformationFezup> InformationFezupRepository, IMapper mapper)
        {
            _InformationFezupRepository = InformationFezupRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InformationFezupDto>> Handle(GetInformationFezupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<InformationFezup> InformationFezups = _InformationFezupRepository.FilterWithInclude(x => (x.PONo.Contains(request.QueryParams.SearchText) || x.MemberName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = InformationFezups.Count();
            InformationFezups = InformationFezups.OrderByDescending(x => x.InformationFezupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InformationFezupDtos = _mapper.Map<List<InformationFezupDto>>(InformationFezups);
            var result = new PagedResult<InformationFezupDto>(InformationFezupDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
