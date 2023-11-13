using SchoolManagement.Application.Features.InventoryTypes.Requests.Queries;
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
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InventoryTypes.Handlers.Queries
{
    public class GetInventoryTypeListRequestHandler : IRequestHandler<GetInventoryTypeListRequest, PagedResult<InventoryTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InventoryType> _InventoryTypeRepository;

        private readonly IMapper _mapper;

        public GetInventoryTypeListRequestHandler(ISchoolManagementRepository<InventoryType> InventoryTypeRepository, IMapper mapper)
        {
            _InventoryTypeRepository = InventoryTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InventoryTypeDto>> Handle(GetInventoryTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<InventoryType> InventoryTypes = _InventoryTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = InventoryTypes.Count();
            InventoryTypes = InventoryTypes.OrderByDescending(x => x.InventoryTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InventoryTypeDtos = _mapper.Map<List<InventoryTypeDto>>(InventoryTypes);
            var result = new PagedResult<InventoryTypeDto>(InventoryTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
