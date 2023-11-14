using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookInformations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookInformations.Handlers.Queries
{
    public class GetAccessionNoIsExistCheckRequestHandler : IRequestHandler<GetAccessionNoIsExistCheckRequest, bool>
    {
        private readonly ISchoolManagementRepository<BookInformation> _BookInformationRepository; 
        public GetAccessionNoIsExistCheckRequestHandler(ISchoolManagementRepository<BookInformation> BookInformationRepository)
        {
            _BookInformationRepository = BookInformationRepository;
        }
          
        public async Task<bool> Handle(GetAccessionNoIsExistCheckRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookInformation> bookList = await _BookInformationRepository.FilterAsync(x => x.IsActive);
            bool isExist = bookList.Any(x => x.AccessionNo == request.AccessionNo);
            if (isExist)
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
      }
}
