﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class PaymentDetail
    {
        public int PaymentDetailId { get; set; }
        public int? TraineeId { get; set; }
        public string NumberOfInstallment { get; set; }
        public string UsdRate { get; set; }
        public string TotalUsd { get; set; }
        public string TotalBdt { get; set; }
        public string Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
