using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class CategoryLimit
    {
        public int Id { get; set; }
        public long CatId { get; set; }
        public int Limit { get; set; }
        public string CreateId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LastUpdateId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
