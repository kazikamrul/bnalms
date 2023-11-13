using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Queries
{
    public class GetSelectedSecurityQuestionRequestHandler : IRequestHandler<GetSelectedSecurityQuestionRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SecurityQuestion> _SecurityQuestionRepository;


        public GetSelectedSecurityQuestionRequestHandler(ISchoolManagementRepository<SecurityQuestion> SecurityQuestionRepository)
        {
            _SecurityQuestionRepository = SecurityQuestionRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSecurityQuestionRequest request, CancellationToken cancellationToken)
        {
            ICollection<SecurityQuestion> codeValues = await _SecurityQuestionRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SecurityQuestionId
            }).ToList();
            return selectModels;
        }
    }
}
