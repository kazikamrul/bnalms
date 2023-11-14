using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BookSelfInfo
    {
        public long BookSelfIdentity { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public long BookId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateUserId { get; set; }
    }
}
