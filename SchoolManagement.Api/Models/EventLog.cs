using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class EventLog
    {
        public string UserId { get; set; }
        public string EventName { get; set; }
        public DateTime EventTime { get; set; }
        public string PreviousInfo { get; set; }
        public string CurrentInfo { get; set; }
        public string Workstation { get; set; }
        public int Slno { get; set; }
        public string BranchCode { get; set; }
    }
}
