using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AllBookInfo
    {
        public long Category { get; set; }
        public string CoverImage { get; set; }
        public int? IssueDay { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int? Arabic { get; set; }
        public int? Romanic { get; set; }
        public string CallNumber { get; set; }
        public long BookInfoIdentity { get; set; }
        public long MeargeId { get; set; }
        public string TitleCategory { get; set; }
        public string TitleBangla { get; set; }
        public string BookCategory { get; set; }
        public long? RequestedStatus { get; set; }
        public bool? IsBinding { get; set; }
        public long BookId { get; set; }
        public long BookTitle { get; set; }
        public string BookTitleName { get; set; }
        public string BookSubtitle { get; set; }
        public string Language { get; set; }
        public string Issn { get; set; }
        public string Heading { get; set; }
        public string Isbn { get; set; }
        public int NoOfBooks { get; set; }
        public bool? IsDamage { get; set; }
        public decimal? Amount { get; set; }
        public long? Source { get; set; }
        public bool? BookStatus { get; set; }
        public string Edition { get; set; }
        public string SelfNo { get; set; }
        public string SelfRowNo { get; set; }
        public int? Volumn { get; set; }
        public string Notes { get; set; }
        public string AuthorName { get; set; }
        public string PublishersName { get; set; }
        public string PublishersAddress { get; set; }
        public string PublisherDate { get; set; }
        public string PublisherPlace { get; set; }
        public string DonorName { get; set; }
        public int? DonorPhone { get; set; }
        public string DonorEmail { get; set; }
        public string DonorAddress { get; set; }
        public DateTime? DonationDate { get; set; }
        public string SupplierName { get; set; }
        public bool? Issueable { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public string Email { get; set; }
        public DateTime? SuppliedDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string LastUpdateId { get; set; }
    }
}
