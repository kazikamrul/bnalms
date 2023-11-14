﻿using MediatR;

namespace SchoolManagement.Application.Features.CourseInstructors.Requests.Queries
{
    public class GetInstructorByBaseSchoolAndCourseNameSpRequest : IRequest<object>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
        public int CourseDurationId { get; set; }
    }
} 
