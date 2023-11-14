using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Sources.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Sources.Handlers.Queries
{
    public class GetSelectedSourceRequestHandler : IRequestHandler<GetSelectedSourceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Source> _SourceRepository;


        public GetSelectedSourceRequestHandler(ISchoolManagementRepository<Source> SourceRepository)
        {
            _SourceRepository = SourceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSourceRequest request, CancellationToken cancellationToken)
        {
            ICollection<Source> codeValues = await _SourceRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.SourceId
            }).ToList();
            return selectModels;
        }
    }
}
