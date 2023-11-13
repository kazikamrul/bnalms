using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using SchoolManagement.Application.Features.BookCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Queries
{
    public class GetAllBookCategoriesListRequestHandler : IRequestHandler<GetAllBookCategoriesListRequest, List<BookCategoryDto>>
    {
        private readonly ISchoolManagementRepository<BookCategory> _BookCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllBookCategoriesListRequestHandler(ISchoolManagementRepository<BookCategory> BookCategoryRepository, IMapper mapper)
        {
            _BookCategoryRepository = BookCategoryRepository;
            _mapper = mapper;
        }

        public async Task<List<BookCategoryDto>> Handle(GetAllBookCategoriesListRequest request, CancellationToken cancellationToken)
        {
            IQueryable<BookCategory> bookCategories =  _BookCategoryRepository.FilterWithInclude(x => x.IsActive);
            //List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            //{
            //    Text = x.BookCategoryName,
            //    Value = x.BookCategoryId
            //}).ToList();
            var bookCategoriesDtos = _mapper.Map<List<BookCategoryDto>>(bookCategories);
            return bookCategoriesDtos;
        }

    }
}
