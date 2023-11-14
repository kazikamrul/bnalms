using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.Features.BookCategorys.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BookCategorys.Handlers.Queries
{
    public class GetBookCategoryDetailRequestHandler : IRequestHandler<GetBookCategoryDetailRequest, BookCategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BookCategory> _BookCategoryRepository;
        public GetBookCategoryDetailRequestHandler(ISchoolManagementRepository<BookCategory> BookCategoryRepository, IMapper mapper)
        {
            _BookCategoryRepository = BookCategoryRepository;
            _mapper = mapper;
        }
        public async Task<BookCategoryDto> Handle(GetBookCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var BookCategory = await _BookCategoryRepository.Get(request.BookCategoryId);
            return _mapper.Map<BookCategoryDto>(BookCategory);
        }
    }
}
