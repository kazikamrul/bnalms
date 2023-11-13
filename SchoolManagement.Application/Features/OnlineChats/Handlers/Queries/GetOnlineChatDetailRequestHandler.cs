using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetOnlineChatDetailRequestHandler : IRequestHandler<GetOnlineChatDetailRequest, OnlineChatDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OnlineChat> _OnlineChatRepository;
        public GetOnlineChatDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.OnlineChat> OnlineChatRepository, IMapper mapper)
        {
            _OnlineChatRepository = OnlineChatRepository;
            _mapper = mapper;
        }
        public async Task<OnlineChatDto> Handle(GetOnlineChatDetailRequest request, CancellationToken cancellationToken)
        {
            var OnlineChat = await _OnlineChatRepository.Get(request.OnlineChatId);
            return _mapper.Map<OnlineChatDto>(OnlineChat);
        }
    }
}
