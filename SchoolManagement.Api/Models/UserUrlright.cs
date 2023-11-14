using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class UserUrlright
    {
        public string MenuId { get; set; }
        public Guid ApplicationId { get; set; }
        public string UserId { get; set; }
        public string MenuObjectName { get; set; }
        public string MenuObjectDescription { get; set; }
        public string UrlLink { get; set; }
        public bool? AddInfo { get; set; }
        public bool? ChangeInfo { get; set; }
        public bool? DeleteInfo { get; set; }
        public bool? ExecuteProc { get; set; }
        public bool? Visible { get; set; }
        public string TableName { get; set; }
        public string Spname { get; set; }
        public string GroupName { get; set; }
        public string MenuLevel { get; set; }
        public string FirstLevel { get; set; }
        public string SecondLevel { get; set; }
        public string ThirdLevel { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
