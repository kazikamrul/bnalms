using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.SecurityQuestions.Requests.Queries
{
    public class GetSelectedSecurityQuestionRequest : IRequest<List<SelectedModel>>
    {
    }
}
