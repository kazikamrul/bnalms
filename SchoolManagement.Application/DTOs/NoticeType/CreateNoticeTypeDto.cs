using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.NoticeType
{
    public class CreateNoticeTypeDto : INoticeTypeDto  
    {
        public int NoticeTypeId { get; set; }
        public string? Name { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
