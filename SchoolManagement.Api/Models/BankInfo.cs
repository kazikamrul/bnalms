using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BankInfo
    {
        public string BrCode { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string CountryCode { get; set; }
        public string BranchType { get; set; }
        public string NativeBranchCode { get; set; }
        public string NativeBranchName { get; set; }
        public string BranchAddress { get; set; }
        public string ZoneName { get; set; }
        public string ZoneCode { get; set; }
        public string SubBranchCode { get; set; }
        public string SubBranchName { get; set; }
        public string CountryName { get; set; }
        public string BranchLevel { get; set; }
        public string RoutingNo { get; set; }
        public string Address { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
