﻿using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.OnlineChat;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineChat
{

    
    public class CreateOnlineChatDto : IOnlineChatDto
    {
        public int OnlineChatId { get; set; }
        public int? SendBaseSchoolNameId { get; set; }
        public int? ReceivedBaseSchoolNameId { get; set; }
        public string? SenderRole { get; set; }
        public string? ReceiverRole { get; set; }
        public string? Notes { get; set; }
        public int? ReciverSeenStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
