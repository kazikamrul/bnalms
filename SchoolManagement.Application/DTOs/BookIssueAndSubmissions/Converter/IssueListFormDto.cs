using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.BookIssueAndSubmission.Converter
{
    public class IssueListFormDto 
    {
        public int? BookInformationId { get; set; }
        public int? ShelfInfoId { get; set; }
        public int? RowInfoId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }        
    }
}
