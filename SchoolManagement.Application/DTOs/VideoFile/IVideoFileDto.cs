using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.VideoFile
{
    public interface IVideoFileDto
    {
        public int VideoFileId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
