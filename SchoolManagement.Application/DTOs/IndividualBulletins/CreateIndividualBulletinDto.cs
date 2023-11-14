﻿using System;

namespace SchoolManagement.Application.DTOs.IndividualBulletins
{ 
    public class CreateIndividualBulletinDto : IIndividualBulletinDto 
    {
        public int IndividualBulletinId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? TraineeId { get; set; }
        public int? Status { get; set; }
        public string? BulletinDetails { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool? IsActive { get; set; }
    }
}
