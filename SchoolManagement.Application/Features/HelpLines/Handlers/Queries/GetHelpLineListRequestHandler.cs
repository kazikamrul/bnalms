using SchoolManagement.Application.Features.HelpLines.Requests.Queries;
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
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Queries
{
    public class GetHelpLineListRequestHandler : IRequestHandler<GetHelpLineListRequest, PagedResult<HelpLineDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.HelpLine> _HelpLineRepository;

        private readonly IMapper _mapper;

        public GetHelpLineListRequestHandler(ISchoolManagementRepository<HelpLine> HelpLineRepository, IMapper mapper)
        {
            _HelpLineRepository = HelpLineRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<HelpLineDto>> Handle(GetHelpLineListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<HelpLine> HelpLines = _HelpLineRepository.FilterWithInclude(x => (x.HelpContact.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = HelpLines.Count();
            HelpLines = HelpLines.OrderByDescending(x => x.HelpLineId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var HelpLineDtos = _mapper.Map<List<HelpLineDto>>(HelpLines);
            var result = new PagedResult<HelpLineDto>(HelpLineDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
