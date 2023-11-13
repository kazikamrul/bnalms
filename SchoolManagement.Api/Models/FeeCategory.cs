using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FeeCategory
    {
        public FeeCategory()
        {
            FeeInformations = new HashSet<FeeInformation>();
        }

        public int FeeCategoryId { get; set; }
        public string FeeCategoryName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
    }
}
