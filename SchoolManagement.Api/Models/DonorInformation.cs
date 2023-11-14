using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DonorInformation
    {
        public long DonorId { get; set; }
        public long BookId { get; set; }
        public string DonorName { get; set; }
        public int? DonorPhone { get; set; }
        public string DonorEmail { get; set; }
        public string DonorAddress { get; set; }
        public DateTime? DonationDate { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
    }
}
