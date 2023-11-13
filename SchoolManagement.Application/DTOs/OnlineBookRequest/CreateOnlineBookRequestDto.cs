﻿using SchoolManagement.Application.DTOs.OnlineBookRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineBookRequest
{
    public class CreateOnlineBookRequestDto : IOnlineBookRequestDto
    {
        public int OnlineBookRequestId { get; set; }
        public int? BookInformationId { get; set; }
        public int? MemberInfoId { get; set; }
        public int? RequestStatus { get; set; }
        public int? IssueStatus { get; set; }
        public int? CancelStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? AccessionNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CancelDate { get; set; }
    }
}
