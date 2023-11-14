using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.MainClasses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MainClasses.Handlers.Queries
{
    public class GetSelectedMainClassRequestHandler : IRequestHandler<GetSelectedMainClassRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<MainClass> _MainClassRepository;


        public GetSelectedMainClassRequestHandler(ISchoolManagementRepository<MainClass> MainClassRepository)
        {
            _MainClassRepository = MainClassRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMainClassRequest request, CancellationToken cancellationToken)
        {
            ICollection<MainClass> codeValues = await _MainClassRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.MainClassId
            }).ToList();
            return selectModels;
        }
    }
}
