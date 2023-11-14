using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BookCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Queries
{
    public class GetSelectedBookCategoryRequestHandler : IRequestHandler<GetSelectedBookCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BookCategory> _BookCategoryRepository;


        public GetSelectedBookCategoryRequestHandler(ISchoolManagementRepository<BookCategory> BookCategoryRepository)
        {
            _BookCategoryRepository = BookCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBookCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<BookCategory> codeValues = await _BookCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.BookCategoryName,
                Value = x.BookCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
