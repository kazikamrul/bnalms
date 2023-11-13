using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ShelfInfo
{
    public class CreateShelfInfoDto : IShelfInfoDto  
    {
        public int ShelfInfoId { get; set; }
        public string? ShelfName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
