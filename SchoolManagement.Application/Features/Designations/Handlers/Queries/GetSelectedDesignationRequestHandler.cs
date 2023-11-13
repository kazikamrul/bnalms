using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Designations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Designations.Handlers.Queries
{
    public class GetSelectedDesignationRequestHandler : IRequestHandler<GetSelectedDesignationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Designation> _DesignationRepository;


        public GetSelectedDesignationRequestHandler(ISchoolManagementRepository<Designation> DesignationRepository)
        {
            _DesignationRepository = DesignationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDesignationRequest request, CancellationToken cancellationToken)
        {
            ICollection<Designation> codeValues = await _DesignationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.DesignationName,
                Value = x.DesignationId
            }).ToList();
            return selectModels;
        }
    }
}
