using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.JobStatus
{
    public class JobStatusDto : IJobStatusDto
    {
        public int JobStatusId { get; set; }
        public string? JobStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
