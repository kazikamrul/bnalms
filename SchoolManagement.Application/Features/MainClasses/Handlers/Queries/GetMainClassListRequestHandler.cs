using SchoolManagement.Application.Features.MainClasses.Requests.Queries;
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
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MainClasses.Handlers.Queries
{
    public class GetMainClassListRequestHandler : IRequestHandler<GetMainClassListRequest, PagedResult<MainClassDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MainClass> _MainClassRepository;

        private readonly IMapper _mapper;

        public GetMainClassListRequestHandler(ISchoolManagementRepository<MainClass> MainClassRepository, IMapper mapper)
        {
            _MainClassRepository = MainClassRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MainClassDto>> Handle(GetMainClassListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<MainClass> MainClasss = _MainClassRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MainClasss.Count();
            MainClasss = MainClasss.OrderByDescending(x => x.MainClassId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MainClassDtos = _mapper.Map<List<MainClassDto>>(MainClasss);
            var result = new PagedResult<MainClassDto>(MainClassDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
