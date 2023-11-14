using SchoolManagement.Application.Features.SoftCopyUploads.Requests.Queries;
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
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SoftCopyUploads.Handlers.Queries
{
    public class GetSoftCopyUploadListByDocumentTypeRequestHandler : IRequestHandler<GetSoftCopyUploadListByDocumentTypeRequest, PagedResult<SoftCopyUploadDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SoftCopyUpload> _SoftCopyUploadRepository;

        private readonly IMapper _mapper;

        public GetSoftCopyUploadListByDocumentTypeRequestHandler(ISchoolManagementRepository<SoftCopyUpload> SoftCopyUploadRepository, IMapper mapper)
        {
            _SoftCopyUploadRepository = SoftCopyUploadRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<SoftCopyUploadDto>> Handle(GetSoftCopyUploadListByDocumentTypeRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            if(request.BaseSchoolNameId == 1)
            {
                IQueryable<SoftCopyUpload> SoftCopyUploads = _SoftCopyUploadRepository.FilterWithInclude(x => (x.TitleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DocumentType").Where(x=>x.DocumentTypeId == request.DocumentTypeId);
                var totalCount = SoftCopyUploads.Count();
                SoftCopyUploads = SoftCopyUploads.OrderByDescending(x => x.SoftCopyUploadId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                var SoftCopyUploadDtos = _mapper.Map<List<SoftCopyUploadDto>>(SoftCopyUploads);
                var result = new PagedResult<SoftCopyUploadDto>(SoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                return result;
            }
            else
            {
                IQueryable<SoftCopyUpload> SoftCopyUploads = _SoftCopyUploadRepository.FilterWithInclude(x => (x.TitleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DocumentType").Where(x=>x.BaseSchoolNameId==request.BaseSchoolNameId && x.DocumentTypeId == request.DocumentTypeId);
                var totalCount = SoftCopyUploads.Count();
                SoftCopyUploads = SoftCopyUploads.OrderByDescending(x => x.SoftCopyUploadId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

                var SoftCopyUploadDtos = _mapper.Map<List<SoftCopyUploadDto>>(SoftCopyUploads);
                var result = new PagedResult<SoftCopyUploadDto>(SoftCopyUploadDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

                return result;
            }
          //  return result;

        }
    }
}
