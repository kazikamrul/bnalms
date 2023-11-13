using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SecurityQuestions.Handlers.Queries
{
    public class GetSecurityQuestionDetailRequestHandler : IRequestHandler<GetSecurityQuestionDetailRequest, SecurityQuestionDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SecurityQuestion> _SecurityQuestionRepository;
        public GetSecurityQuestionDetailRequestHandler(ISchoolManagementRepository<SecurityQuestion> SecurityQuestionRepository, IMapper mapper)
        {
            _SecurityQuestionRepository = SecurityQuestionRepository;
            _mapper = mapper;
        }
        public async Task<SecurityQuestionDto> Handle(GetSecurityQuestionDetailRequest request, CancellationToken cancellationToken)
        {
            var SecurityQuestion = await _SecurityQuestionRepository.Get(request.SecurityQuestionId);
            return _mapper.Map<SecurityQuestionDto>(SecurityQuestion);
        }
    }
}
