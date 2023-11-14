using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatListRequestHandler : IRequestHandler<GetOnlineChatListRequest, PagedResult<OnlineChatDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OnlineChat> _OnlineChatRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.OnlineChat> OnlineChatRepository, IMapper mapper)
        {
            _OnlineChatRepository = OnlineChatRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<OnlineChatDto>> Handle(GetOnlineChatListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.OnlineChat> OnlineChats = _OnlineChatRepository.FilterWithInclude(x => (x.Notes.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = OnlineChats.Count();
            OnlineChats = OnlineChats.OrderByDescending(x => x.OnlineChatId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var OnlineChatDtos = _mapper.Map<List<OnlineChatDto>>(OnlineChats);
            var result = new PagedResult<OnlineChatDto>(OnlineChatDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
