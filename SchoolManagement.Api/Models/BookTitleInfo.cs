using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookTitleInfo
    {
        public BookTitleInfo()
        {
            BookInformations = new HashSet<BookInformation>();
        }

        public int BookTitleInfoId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string BookTitleName { get; set; }
        public string TitleBangla { get; set; }
        public string BookSubtitle { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual ICollection<BookInformation> BookInformations { get; set; }
    }
}
