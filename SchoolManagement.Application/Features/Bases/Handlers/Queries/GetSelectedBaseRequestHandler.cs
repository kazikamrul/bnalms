using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Bases.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bases.Handlers.Queries
{
    public class GetSelectedBaseRequestHandler : IRequestHandler<GetSelectedBaseRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Base> _BaseRepository;


        public GetSelectedBaseRequestHandler(ISchoolManagementRepository<Base> BaseRepository)
        {
            _BaseRepository = BaseRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBaseRequest request, CancellationToken cancellationToken)
        {
            ICollection<Base> codeValues = await _BaseRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.BaseId
            }).ToList();
            return selectModels;
        }
    }
}
