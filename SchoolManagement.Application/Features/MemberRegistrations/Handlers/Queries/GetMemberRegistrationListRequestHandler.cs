using SchoolManagement.Application.Features.MemberRegistrations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MemberRegistrations.Handlers.Queries
{
    public class GetMemberRegistrationListRequestHandler : IRequestHandler<GetMemberRegistrationListRequest, PagedResult<MemberRegistrationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MemberRegistration> _MemberRegistrationRepository;

        private readonly IMapper _mapper;

        public GetMemberRegistrationListRequestHandler(ISchoolManagementRepository<MemberRegistration> MemberRegistrationRepository, IMapper mapper)
        {
            _MemberRegistrationRepository = MemberRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MemberRegistrationDto>> Handle(GetMemberRegistrationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MemberRegistration> MemberRegistrations = _MemberRegistrationRepository.FilterWithInclude(x => (x.MemberName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MemberRegistrations.Count();
            MemberRegistrations = MemberRegistrations.OrderByDescending(x => x.MemberRegistrationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MemberRegistrationDtos = _mapper.Map<List<MemberRegistrationDto>>(MemberRegistrations);
            var result = new PagedResult<MemberRegistrationDto>(MemberRegistrationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
