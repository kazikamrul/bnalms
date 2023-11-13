using SchoolManagement.Application.Features.JobStatuses.Requests.Queries;
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
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.JobStatuses.Handlers.Queries
{
    public class GetJobStatusListRequestHandler : IRequestHandler<GetJobStatusListRequest, PagedResult<JobStatusDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.JobStatus> _JobStatusRepository;

        private readonly IMapper _mapper;

        public GetJobStatusListRequestHandler(ISchoolManagementRepository<JobStatus> JobStatusRepository, IMapper mapper)
        {
            _JobStatusRepository = JobStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<JobStatusDto>> Handle(GetJobStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<JobStatus> JobStatuss = _JobStatusRepository.FilterWithInclude(x => (x.JobStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = JobStatuss.Count();
            JobStatuss = JobStatuss.OrderByDescending(x => x.JobStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var JobStatusDtos = _mapper.Map<List<JobStatusDto>>(JobStatuss);
            var result = new PagedResult<JobStatusDto>(JobStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
