﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetRunningCourseDurationListBySchoolFromSpRequestHandler : IRequestHandler<GetRunningCourseDurationListBySchoolFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetRunningCourseDurationListBySchoolFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetRunningCourseDurationListBySchoolFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetRunningCourseDurationBySchool] {0},'{1}',{2},{3}", request.CourseTypeId, request.CurrentDate, request.BaseSchoolNameId, request.ViewStatus);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}