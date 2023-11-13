using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MemberOfficialInfo
    {
        public long MemberOfficialIdentiy { get; set; }
        public int MemberId { get; set; }
        public long? Designation { get; set; }
        public string CodeNumber { get; set; }
        public string Department { get; set; }
        public long? JobStatus { get; set; }
        public int? OfficeTnt { get; set; }
        public string OfficeMobileNo { get; set; }
        public int? FaxNumber { get; set; }
        public string PerMobileNo { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdateId { get; set; }
    }
}
