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
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.FineForIssueReturns.Requests.Queries;

namespace SchoolManagement.Application.Features.FineForIssueReturns.Handlers.Queries
{
    public class GetFineForIssueReturnListRequestHandler : IRequestHandler<GetFineForIssueReturnListRequest, PagedResult<FineForIssueReturnDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.FineForIssueReturn> _FineForIssueReturnRepository;

        private readonly IMapper _mapper;

        public GetFineForIssueReturnListRequestHandler(ISchoolManagementRepository<FineForIssueReturn> FineForIssueReturnRepository, IMapper mapper)
        {
            _FineForIssueReturnRepository = FineForIssueReturnRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<FineForIssueReturnDto>> Handle(GetFineForIssueReturnListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<FineForIssueReturn> FineForIssueReturns = _FineForIssueReturnRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = FineForIssueReturns.Count();
            FineForIssueReturns = FineForIssueReturns.OrderByDescending(x => x.FineForIssueReturnId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId);

            var FineForIssueReturnDtos = _mapper.Map<List<FineForIssueReturnDto>>(FineForIssueReturns);
            var result = new PagedResult<FineForIssueReturnDto>(FineForIssueReturnDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}

