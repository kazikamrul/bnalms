using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.AuthorInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AuthorInformations.Handlers.Queries
{
    public class GetSelectedAuthorInformationRequestHandler : IRequestHandler<GetSelectedAuthorInformationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<AuthorInformation> _AuthorInformationRepository;


        public GetSelectedAuthorInformationRequestHandler(ISchoolManagementRepository<AuthorInformation> AuthorInformationRepository)
        {
            _AuthorInformationRepository = AuthorInformationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAuthorInformationRequest request, CancellationToken cancellationToken)
        {
            ICollection<AuthorInformation> codeValues = await _AuthorInformationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.AuthorName,
                Value = x.AuthorInformationId
            }).ToList();
            return selectModels;
        }
    }
}
