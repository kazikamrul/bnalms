using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RegistrationQueueInfo
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Pnumber { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string PersonalNumber { get; set; }
        public string PresentAddress { get; set; }
        public string PresentDuty { get; set; }
        public int? Area { get; set; }
        public long? Base { get; set; }
        public string Organization { get; set; }
        public bool? Seen { get; set; }
        public bool? IsAccept { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual CommonCode AreaNavigation { get; set; }
        public virtual CommonCode CategoryNavigation { get; set; }
    }
}
