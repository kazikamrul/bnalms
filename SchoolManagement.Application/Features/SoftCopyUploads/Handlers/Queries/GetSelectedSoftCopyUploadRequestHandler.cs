using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Queries
{
    public class GetSelectedSoftCopyUploadRequestHandler : IRequestHandler<GetSelectedSoftCopyUploadRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SoftCopyUpload> _SoftCopyUploadRepository;


        public GetSelectedSoftCopyUploadRequestHandler(ISchoolManagementRepository<SoftCopyUpload> SoftCopyUploadRepository)
        {
            _SoftCopyUploadRepository = SoftCopyUploadRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSoftCopyUploadRequest request, CancellationToken cancellationToken)
        {
            ICollection<SoftCopyUpload> codeValues = await _SoftCopyUploadRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.TitleName,
                Value = x.SoftCopyUploadId
            }).ToList();
            return selectModels;
        }
    }
}
