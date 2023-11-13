using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BranchInfo
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string CountryCode { get; set; }
        public string ZoneCode { get; set; }
        public string BranchLevel { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string ThirdLevel { get; set; }
        public string FourthLevel { get; set; }
        public string FifthLevel { get; set; }
        public string BranchType { get; set; }
        public string NativeBranchCode { get; set; }
        public string CurrencyCode { get; set; }
        public string OwnBranchCode { get; set; }
        public string AccountNoFc { get; set; }
        public string AccountNoLc { get; set; }
        public string UserId { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
