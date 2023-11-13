using SchoolManagement.Application.Features.AuthorInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Queries
{
    public class GetAuthorInformationListRequestHandler : IRequestHandler<GetAuthorInformationListRequest, PagedResult<AuthorInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.AuthorInformation> _AuthorInformationRepository;

        private readonly IMapper _mapper;

        public GetAuthorInformationListRequestHandler(ISchoolManagementRepository<AuthorInformation> AuthorInformationRepository, IMapper mapper)
        {
            _AuthorInformationRepository = AuthorInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<AuthorInformationDto>> Handle(GetAuthorInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<AuthorInformation> AuthorInformations = _AuthorInformationRepository.FilterWithInclude(x => (x.AuthorName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "AuthorityCategory", "BookInformation.BookTitleInfo");
            var totalCount = AuthorInformations.Count();
            AuthorInformations = AuthorInformations.OrderByDescending(x => x.AuthorInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BookInformationId == request.BookInformationId);

            var AuthorInformationDtos = _mapper.Map<List<AuthorInformationDto>>(AuthorInformations);
            var result = new PagedResult<AuthorInformationDto>(AuthorInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
