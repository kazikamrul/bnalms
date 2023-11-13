using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AuthorInfoSingleLine
    {
        public long? Row { get; set; }
        public long BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string TypeValue { get; set; }
        public long BookId { get; set; }
    }
}
