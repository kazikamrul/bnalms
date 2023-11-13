using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CommonCode
    {
        public CommonCode()
        {
            RegistrationQueueInfoAreaNavigations = new HashSet<RegistrationQueueInfo>();
            RegistrationQueueInfoCategoryNavigations = new HashSet<RegistrationQueueInfo>();
        }

        public int CommonCodeId { get; set; }
        public string BankCode { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string TypeValue { get; set; }
        public string AdditonalValue { get; set; }
        public string DisplayCode { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }
        public string UserId { get; set; }
        public DateTime? LastUpdate { get; set; }

        public virtual ICollection<RegistrationQueueInfo> RegistrationQueueInfoAreaNavigations { get; set; }
        public virtual ICollection<RegistrationQueueInfo> RegistrationQueueInfoCategoryNavigations { get; set; }
    }
}
