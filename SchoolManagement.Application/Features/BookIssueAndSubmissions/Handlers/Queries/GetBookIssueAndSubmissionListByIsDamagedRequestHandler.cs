using SchoolManagement.Application.Features.BookIssueAndSubmissions.Requests.Queries;
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
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BookIssueAndSubmissions.Handlers.Queries
{
    public class GetBookIssueAndSubmissionListByIsDamagedRequestHandler : IRequestHandler<GetBookIssueAndSubmissionListByIsDamagedRequest, PagedResult<BookIssueAndSubmissionDto>>
    {

        private readonly ISchoolManagementRepository<BookIssueAndSubmission> _BookIssueAndSubmissionRepository;

        private readonly IMapper _mapper;

        public GetBookIssueAndSubmissionListByIsDamagedRequestHandler(ISchoolManagementRepository<BookIssueAndSubmission> BookIssueAndSubmissionRepository, IMapper mapper)
        {
            _BookIssueAndSubmissionRepository = BookIssueAndSubmissionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookIssueAndSubmissionDto>> Handle(GetBookIssueAndSubmissionListByIsDamagedRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<BookIssueAndSubmission> BookIssueAndSubmissions = _BookIssueAndSubmissionRepository.FilterWithInclude(x => ((x.BookInformation.MergeId.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)) && x.IsDamage == "Y"), "MemberInfo","BookInformation.BookTitleInfo", "BookInformation");
            var totalCount = BookIssueAndSubmissions.Count();
            BookIssueAndSubmissions = BookIssueAndSubmissions.OrderByDescending(x => x.BookIssueAndSubmissionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BookIssueAndSubmissionDtos = _mapper.Map<List<BookIssueAndSubmissionDto>>(BookIssueAndSubmissions);
            var result = new PagedResult<BookIssueAndSubmissionDto>(BookIssueAndSubmissionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
