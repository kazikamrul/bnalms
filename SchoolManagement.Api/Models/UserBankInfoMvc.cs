using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class UserBankInfoMvc
    {
        public string CountryName { get; set; }
        public string BranchCode { get; set; }
        public string BankName { get; set; }
        public string DistrictName { get; set; }
        public string BranchName { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string BankCode { get; set; }
        public string SubBranchCode { get; set; }
        public string SubBranchName { get; set; }
        public string BrCode { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public decimal? TransLimit { get; set; }
        public string LoweredRoleName { get; set; }
        public string NativeBranchCode { get; set; }
        public bool ApprovedUser { get; set; }
        public int? AttemptCount { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public long? MemberId { get; set; }
        public string ImageUrl { get; set; }
        public long? Category { get; set; }
    }
}
