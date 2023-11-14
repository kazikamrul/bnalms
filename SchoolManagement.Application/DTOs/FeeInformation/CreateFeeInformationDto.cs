using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FeeInformation
{
    public class CreateFeeInformationDto : IFeeInformationDto  
    {
        public int FeeInformationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? BookInformationId { get; set; }
        public int? MemberInfoId { get; set; }
        public int? FeeCategoryId { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public double? PaidAmount { get; set; }
        public string? ReceivedAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
