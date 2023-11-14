using SchoolManagement.Application.Features.VideoFiles.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.VideoFile;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.VideoFiles.Handlers.Queries
{
    public class GetVideoFileListRequestHandler : IRequestHandler<GetVideoFileListRequest, PagedResult<VideoFileDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.VideoFile> _VideoFileRepository;

        private readonly IMapper _mapper;

        public GetVideoFileListRequestHandler(ISchoolManagementRepository<VideoFile> VideoFileRepository, IMapper mapper)
        {
            _VideoFileRepository = VideoFileRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<VideoFileDto>> Handle(GetVideoFileListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<VideoFile> VideoFiles = _VideoFileRepository.FilterWithInclude(x => (x.DocumentName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = VideoFiles.Count();
            VideoFiles = VideoFiles.OrderByDescending(x => x.VideoFileId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var VideoFileDtos = _mapper.Map<List<VideoFileDto>>(VideoFiles);
            var result = new PagedResult<VideoFileDto>(VideoFileDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
