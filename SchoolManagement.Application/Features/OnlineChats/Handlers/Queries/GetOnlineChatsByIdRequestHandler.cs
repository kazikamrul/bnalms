using AutoMapper;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries   
{
    public class GetOnlineChatsByIdRequestHandler : IRequestHandler<GetOnlineChatsByIdRequest, List<OnlineChatDto>>
    {

        private readonly ISchoolManagementRepository<OnlineChat> _OnlineChatRepository;

        private readonly IMapper _mapper;

        public GetOnlineChatsByIdRequestHandler(ISchoolManagementRepository<OnlineChat> OnlineChatRepository, IMapper mapper)
        {
            _OnlineChatRepository = OnlineChatRepository;
            _mapper = mapper;
        }

        public async Task<List<OnlineChatDto>> Handle(GetOnlineChatsByIdRequest request, CancellationToken cancellationToken)
        {
            //if(request.UserRole == "Super Admin")
            //{
            //    IQueryable<OnlineChat> OnlineChats = _OnlineChatRepository.FilterWithInclude(x => x.SendBaseSchoolNameId == request.TargetId || x.ReceivedBaseSchoolNameId == request.TargetId);
            //    var OnlineChatDtos = _mapper.Map<List<OnlineChatDto>>(OnlineChats);
            //    return OnlineChatDtos;
            //}
            //else 
            //if(request.UserRole == "Master Admin" || request.UserRole == "DDNT")
            //{
            //    IQueryable<OnlineChat> OnlineChats = _OnlineChatRepository.FilterWithInclude(x => (x.SenderRole == request.UserRole && x.ReceivedBaseSchoolNameId == request.TargetId) || ((x.SenderRole == "Super Admin" || x.SenderRole == "School OIC") && x.SendBaseSchoolNameId == request.TargetId && x.ReceivedBaseSchoolNameId == null));
            //    var OnlineChatDtos = _mapper.Map<List<OnlineChatDto>>(OnlineChats);
            //    return OnlineChatDtos;
            //}
            //else
            //{
                //IQueryable<OnlineChat> OnlineChats = _OnlineChatRepository.FilterWithInclude(x => (x.SenderRole == request.UserRole && x.SendBaseSchoolNameId == request.SenderId && x.ReceivedBaseSchoolNameId == request.ReciverId) || ((x.SenderRole == "Admin") && x.ReceiverRole==request.UserRole && x.SendBaseSchoolNameId == request.SenderId && x.ReceivedBaseSchoolNameId == request.ReciverId) || (x.SenderRole==request.UserRole && x.ReceivedBaseSchoolNameId == request.SenderId) || (x.ReceiverRole == request.UserRole && x.ReceivedBaseSchoolNameId == request.SenderId));
                IQueryable<OnlineChat> OnlineChats = _OnlineChatRepository.FilterWithInclude(x => (x.SenderRole == request.UserRole && x.SendBaseSchoolNameId == request.SenderId && x.ReceivedBaseSchoolNameId == request.ReciverId) || (x.ReceiverRole == request.UserRole && x.SendBaseSchoolNameId == request.ReciverId && x.ReceivedBaseSchoolNameId == request.SenderId));
                var OnlineChatDtos = _mapper.Map<List<OnlineChatDto>>(OnlineChats);
                return OnlineChatDtos;
            //}
            //return null;
        }
    }
}
