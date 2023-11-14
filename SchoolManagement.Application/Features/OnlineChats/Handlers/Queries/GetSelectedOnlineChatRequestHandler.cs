using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.OnlineChats.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineChats.Handlers.Queries
{
    public class GetSelectedOnlineChatRequestHandler : IRequestHandler<GetSelectedOnlineChatRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<OnlineChat> _OnlineChatRepository;


        public GetSelectedOnlineChatRequestHandler(ISchoolManagementRepository<OnlineChat> OnlineChatRepository)
        {
            _OnlineChatRepository = OnlineChatRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedOnlineChatRequest request, CancellationToken cancellationToken)
        {
            ICollection<OnlineChat> codeValues = await _OnlineChatRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Notes,
                Value = x.OnlineChatId
            }).ToList();
            return selectModels;
        }
    }
}
