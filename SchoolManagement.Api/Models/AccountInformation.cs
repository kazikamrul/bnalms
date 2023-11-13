using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AccountInformation
    {
        public long AccountInformationIdentity { get; set; }
        public string BankCode { get; set; }
        public string AccountCode { get; set; }
        public string AccountHead { get; set; }
        public long Category { get; set; }
        public long AccountStatusCode { get; set; }
        public string AccountLevel { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string ThirdLevel { get; set; }
        public string FourthLevel { get; set; }
        public string FifthLevel { get; set; }
        public string UserId { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
