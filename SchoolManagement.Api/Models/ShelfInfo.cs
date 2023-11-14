using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ShelfInfo
    {
        public ShelfInfo()
        {
            BookInformations = new HashSet<BookInformation>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
            RowInfos = new HashSet<RowInfo>();
        }

        public int ShelfInfoId { get; set; }
        public string ShelfName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BookInformation> BookInformations { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual ICollection<RowInfo> RowInfos { get; set; }
    }
}
