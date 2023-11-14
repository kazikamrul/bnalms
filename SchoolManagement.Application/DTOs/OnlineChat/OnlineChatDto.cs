using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineChat
{
    public class OnlineChatDto : IOnlineChatDto
    {
        public int OnlineChatId { get; set; }
        public int? SendBaseSchoolNameId { get; set; }
        public int? ReceivedBaseSchoolNameId { get; set; }
        public string? SenderRole { get; set; }
        public string? ReceiverRole { get; set; }
        public string? Notes { get; set; }
        public int? ReciverSeenStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
