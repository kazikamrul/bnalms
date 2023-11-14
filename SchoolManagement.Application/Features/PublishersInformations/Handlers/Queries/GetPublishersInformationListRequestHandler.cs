using SchoolManagement.Application.Features.PublishersInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.PublishersInformations.Handlers.Queries
{
    public class GetPublishersInformationListRequestHandler : IRequestHandler<GetPublishersInformationListRequest, PagedResult<PublishersInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.PublishersInformation> _PublishersInformationRepository;

        private readonly IMapper _mapper;

        public GetPublishersInformationListRequestHandler(ISchoolManagementRepository<PublishersInformation> PublishersInformationRepository, IMapper mapper)
        {
            _PublishersInformationRepository = PublishersInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PublishersInformationDto>> Handle(GetPublishersInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<PublishersInformation> PublishersInformations = _PublishersInformationRepository.FilterWithInclude(x => (x.PublishersName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BookInformation.BookTitleInfo");
            var totalCount = PublishersInformations.Count();
            PublishersInformations = PublishersInformations.OrderByDescending(x => x.PublishersInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BookInformationId == request.BookInformationId);

            var PublishersInformationDtos = _mapper.Map<List<PublishersInformationDto>>(PublishersInformations);
            var result = new PagedResult<PublishersInformationDto>(PublishersInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
