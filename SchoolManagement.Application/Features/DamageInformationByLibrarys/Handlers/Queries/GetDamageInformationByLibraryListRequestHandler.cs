using SchoolManagement.Application.Features.DamageInformationByLibrarys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DamageInformationByLibrarys.Handlers.Queries
{
    public class GetDamageInformationByLibraryListRequestHandler : IRequestHandler<GetDamageInformationByLibraryListRequest, PagedResult<DamageInformationByLibraryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.DamageInformationByLibrary> _DamageInformationByLibraryRepository;

        private readonly IMapper _mapper;

        public GetDamageInformationByLibraryListRequestHandler(ISchoolManagementRepository<DamageInformationByLibrary> DamageInformationByLibraryRepository, IMapper mapper)
        {
            _DamageInformationByLibraryRepository = DamageInformationByLibraryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<DamageInformationByLibraryDto>> Handle(GetDamageInformationByLibraryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<DamageInformationByLibrary> DamageInformationByLibrarys = _DamageInformationByLibraryRepository.FilterWithInclude(x => (x.DamageBy.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookInformation.BookTitleInfo", "BookInformation");
            var totalCount = DamageInformationByLibrarys.Count();
            DamageInformationByLibrarys = DamageInformationByLibrarys.OrderByDescending(x => x.DamageInformationByLibraryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var DamageInformationByLibraryDtos = _mapper.Map<List<DamageInformationByLibraryDto>>(DamageInformationByLibrarys);
            var result = new PagedResult<DamageInformationByLibraryDto>(DamageInformationByLibraryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
