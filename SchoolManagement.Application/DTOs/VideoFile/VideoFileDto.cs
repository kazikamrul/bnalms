using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.VideoFile
{
    public class VideoFileDto : IVideoFileDto
    {
        public int VideoFileId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
