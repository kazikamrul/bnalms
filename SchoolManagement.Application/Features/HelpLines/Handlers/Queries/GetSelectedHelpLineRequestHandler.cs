using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.HelpLines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HelpLines.Handlers.Queries
{
    public class GetSelectedHelpLineRequestHandler : IRequestHandler<GetSelectedHelpLineRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<HelpLine> _HelpLineRepository;


        public GetSelectedHelpLineRequestHandler(ISchoolManagementRepository<HelpLine> HelpLineRepository)
        {
            _HelpLineRepository = HelpLineRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedHelpLineRequest request, CancellationToken cancellationToken)
        {
            ICollection<HelpLine> codeValues = await _HelpLineRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.HelpContact,
                Value = x.HelpLineId
            }).ToList();
            return selectModels;
        }
    }
}
