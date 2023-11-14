using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RowInfo
    {
        public RowInfo()
        {
            BookInformations = new HashSet<BookInformation>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
        }

        public int RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public string RowName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ShelfInfo ShelfInfo { get; set; }
        public virtual ICollection<BookInformation> BookInformations { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
    }
}
