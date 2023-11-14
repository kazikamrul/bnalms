using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FeeSetup
    {
        public long FeeSetupIdentity { get; set; }
        public string FeeCategory { get; set; }
        public int? FeeDuraTion { get; set; }
        public int? Amount { get; set; }
    }
}
