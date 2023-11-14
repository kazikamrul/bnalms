using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using System.Data;
using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetSoftCopyUploadsByTypeListSpRequestHandler : IRequestHandler<GetSoftCopyUploadsByTypeListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<SoftCopyUpload> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetSoftCopyUploadsByTypeListSpRequestHandler(ISchoolManagementRepository<SoftCopyUpload> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSoftCopyUploadsByTypeListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetSoftCopyByDocumentType] {0}", request.DocumentTypeId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
