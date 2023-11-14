using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetSelectedBulletinRequestHandler : IRequestHandler<GetSelectedBulletinRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Bulletin> _BulletinRepository;


        public GetSelectedBulletinRequestHandler(ISchoolManagementRepository<Bulletin> BulletinRepository)
        {
            _BulletinRepository = BulletinRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBulletinRequest request, CancellationToken cancellationToken)
        {
            ICollection<Bulletin> codeValues = await _BulletinRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BuletinDetails,
                Value = x.BulletinId
            }).ToList();
            return selectModels;
        }
    }
}
