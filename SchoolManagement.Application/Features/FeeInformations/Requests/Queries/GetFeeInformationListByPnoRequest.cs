using MediatR;
using SchoolManagement.Application.DTOs.FeeInformation;

namespace SchoolManagement.Application.Features.FeeInformations.Requests.Queries
{
    public class GetFeeInformationListByPnoRequest : IRequest<List<FeeInformationDto>>
    {
        
        public int MemberInfoId { get; set; }
    } 
}

