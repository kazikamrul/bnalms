using SchoolManagement.Application.Features.OnlineBookRequests.Requests.Queries;
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
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OnlineBookRequests.Handlers.Queries
{
    public class GetOnlineBookRequestListRequestHandler : IRequestHandler<GetOnlineBookRequestListRequest, PagedResult<OnlineBookRequestDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OnlineBookRequest> _OnlineBookRequestRepository;

        private readonly IMapper _mapper;

        public GetOnlineBookRequestListRequestHandler(ISchoolManagementRepository<OnlineBookRequest> OnlineBookRequestRepository, IMapper mapper)
        {
            _OnlineBookRequestRepository = OnlineBookRequestRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OnlineBookRequestDto>> Handle(GetOnlineBookRequestListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<OnlineBookRequest> OnlineBookRequests = _OnlineBookRequestRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = OnlineBookRequests.Count();
            OnlineBookRequests = OnlineBookRequests.OrderByDescending(x => x.OnlineBookRequestId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OnlineBookRequestDtos = _mapper.Map<List<OnlineBookRequestDto>>(OnlineBookRequests);
            var result = new PagedResult<OnlineBookRequestDto>(OnlineBookRequestDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
