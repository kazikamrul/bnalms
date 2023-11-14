using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RegistrationQueueInfo1
    {
        public int Id { get; set; }
        public long Category { get; set; }
        public string Pnumber { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string Nid { get; set; }
        public long? SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public bool? Seen { get; set; }
        public bool? IsAccept { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
