using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class UserLogInfo
    {
        public long SlNo { get; set; }
        public string LoginUserId { get; set; }
        public string Workstation { get; set; }
        public string Ipaddress { get; set; }
        public string Macaddress { get; set; }
        public DateTime? EventTime { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
    }
}
