using SchoolManagement.Application.Features.Inventorys.Requests.Queries;
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
using SchoolManagement.Application.DTOs.Inventorys;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Inventorys.Handlers.Queries
{
    public class GetInventoryListRequestHandler : IRequestHandler<GetInventoryListRequest, PagedResult<InventoryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Inventory> _InventoryRepository;

        private readonly IMapper _mapper;

        public GetInventoryListRequestHandler(ISchoolManagementRepository<Inventory> InventoryRepository, IMapper mapper)
        {
            _InventoryRepository = InventoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InventoryDto>> Handle(GetInventoryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<Inventory> Inventorys = _InventoryRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText), "InventoryType");
            var totalCount = Inventorys.Count();
            Inventorys = Inventorys.OrderByDescending(x => x.InventoryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.InventoryTypeId == request.InventoryTypeId); ; ;

            var InventoryDtos = _mapper.Map<List<InventoryDto>>(Inventorys);
            var result = new PagedResult<InventoryDto>(InventoryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
