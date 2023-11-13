using SchoolManagement.Application.Features.ReaderInformations.Requests.Queries;
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
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ReaderInformations.Handlers.Queries
{
    public class GetReaderInformationListRequestHandler : IRequestHandler<GetReaderInformationListRequest, PagedResult<ReaderInformationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReaderInformation> _ReaderInformationRepository;

        private readonly IMapper _mapper;

        public GetReaderInformationListRequestHandler(ISchoolManagementRepository<ReaderInformation> ReaderInformationRepository, IMapper mapper)
        {
            _ReaderInformationRepository = ReaderInformationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReaderInformationDto>> Handle(GetReaderInformationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<ReaderInformation> ReaderInformations = _ReaderInformationRepository.FilterWithInclude(x => (x.ReaderName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "MemberInfo");
            var totalCount = ReaderInformations.Count();
            ReaderInformations = ReaderInformations.OrderByDescending(x => x.ReaderInformationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ReaderInformationDtos = _mapper.Map<List<ReaderInformationDto>>(ReaderInformations);
            var result = new PagedResult<ReaderInformationDto>(ReaderInformationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
