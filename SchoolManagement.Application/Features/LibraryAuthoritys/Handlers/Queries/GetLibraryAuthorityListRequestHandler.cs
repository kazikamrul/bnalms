using SchoolManagement.Application.Features.LibraryAuthoritys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.LibraryAuthority;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.LibraryAuthoritys.Handlers.Queries
{
    public class GetLibraryAuthorityListRequestHandler : IRequestHandler<GetLibraryAuthorityListRequest, PagedResult<LibraryAuthorityDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.LibraryAuthority> _LibraryAuthorityRepository;

        private readonly IMapper _mapper;

        public GetLibraryAuthorityListRequestHandler(ISchoolManagementRepository<LibraryAuthority> LibraryAuthorityRepository, IMapper mapper)
        {
            _LibraryAuthorityRepository = LibraryAuthorityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LibraryAuthorityDto>> Handle(GetLibraryAuthorityListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<LibraryAuthority> LibraryAuthoritys = _LibraryAuthorityRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = LibraryAuthoritys.Count();
            LibraryAuthoritys = LibraryAuthoritys.OrderByDescending(x => x.LibraryAuthorityId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var LibraryAuthorityDtos = _mapper.Map<List<LibraryAuthorityDto>>(LibraryAuthoritys);
            var result = new PagedResult<LibraryAuthorityDto>(LibraryAuthorityDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
