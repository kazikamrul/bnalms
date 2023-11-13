using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RowInfo 
{
    public interface IRowInfoDto 
    {
        public int RowInfoId { get; set; }
        public int? ShelfInfoId { get; set; }
        public string? RowName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    } 
}
