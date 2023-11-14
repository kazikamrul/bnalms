using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Helpers;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Features;
using SchoolManagement.Application.DTOs.Modules;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Application.DTOs.BookTitleInfo;
using SchoolManagement.Application.DTOs.BookCategory;
using SchoolManagement.Application.DTOs.MainClass;
using SchoolManagement.Application.DTOs.RowInfo;
using SchoolManagement.Application.DTOs.ShelfInfo;
using SchoolManagement.Application.DTOs.Language;
using SchoolManagement.Application.DTOs.BookInformation;
using SchoolManagement.Application.DTOs.MemberCategory;
using SchoolManagement.Application.DTOs.Source;
using SchoolManagement.Application.DTOs.AuthorityCategory;
using SchoolManagement.Application.DTOs.AuthorInformation;
using SchoolManagement.Application.DTOs.PublishersInformation;
using SchoolManagement.Application.DTOs.SupplierInformation;
using SchoolManagement.Application.DTOs.SourceInformation;
using SchoolManagement.Application.DTOs.JobStatus;
using SchoolManagement.Application.DTOs.Designation;
using SchoolManagement.Application.DTOs.Rank;
using SchoolManagement.Application.DTOs.MemberInfo;
using SchoolManagement.Application.DTOs.FeeCategory;
using SchoolManagement.Application.DTOs.FeeInformation;
using SchoolManagement.Application.DTOs.ReaderInformation;
using SchoolManagement.Application.DTOs.BookBindingInfo;
using SchoolManagement.Application.DTOs.DamageInformationByLibrary;
using SchoolManagement.Application.DTOs.SoftCopyUpload;
using SchoolManagement.Application.DTOs.NoticeType;
using SchoolManagement.Application.DTOs.NoticeInfo;
using SchoolManagement.Application.DTOs.EventInfo;
using SchoolManagement.Application.DTOs.BookIssueAndSubmission;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.DTOs.InformationFezup;
using SchoolManagement.Application.DTOs.Area;
using SchoolManagement.Application.DTOs.Base;
using SchoolManagement.Application.DTOs.SecurityQuestion;
using SchoolManagement.Application.DTOs.DemandBook;
using SchoolManagement.Application.DTOs.VideoFile;
using SchoolManagement.Application.DTOs.MemberRegistration;
using SchoolManagement.Application.DTOs.OnlineBookRequest;
using SchoolManagement.Application.DTOs.DocumentTypes;
using SchoolManagement.Application.DTOs.HelpLine;
using SchoolManagement.Application.DTOs.LibraryAuthority;
using MediatR;
using SchoolManagement.Application.DTOs.OnlineChat;
using SchoolManagement.Application.DTOs.InventoryTypes;
using SchoolManagement.Application.DTOs.FineForIssueReturns;
using SchoolManagement.Application.DTOs.Inventorys;

namespace SchoolManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Lattar A
            #region AuthorInformation Mapping 
            CreateMap<AuthorInformationDto, AuthorInformation>().ReverseMap()
                .ForMember(d => d.AuthorityCategory, o => o.MapFrom(s => s.AuthorityCategory.AuthorCategoryName))
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla));
            CreateMap<AuthorInformation, CreateAuthorInformationDto>().ReverseMap();
            #endregion

            #region AuthorityCategory Mapping 
            CreateMap<AuthorityCategory, AuthorityCategoryDto>().ReverseMap();
            CreateMap<AuthorityCategory, CreateAuthorityCategoryDto>().ReverseMap();
            #endregion

            //Lattar B

            #region BaseNames Mapping 
            CreateMap<BaseName, BaseNameDto>().ReverseMap();

            CreateMap<BaseName, CreateBaseNameDto>().ReverseMap();
            #endregion

            #region HelpLine Mapping 
            CreateMap<HelpLineDto, HelpLine >().ReverseMap()
                 .ForMember(d => d.SchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                 .ForMember(d => d.ShortName, o => o.MapFrom(s => s.BaseSchoolName.ShortName))
                 .ForMember(d => d.LibraryAuthority, o => o.MapFrom(s => s.LibraryAuthority.Name));
            CreateMap<HelpLine, CreateHelpLineDto>().ReverseMap();
            #endregion



            #region BaseSchoolNames Mapping   
            CreateMap<BaseSchoolNameDto, BaseSchoolName>().ReverseMap()
              .ForMember(d => d.BaseName, o => o.MapFrom(s => s.BaseName.BaseNames))
              .ForMember(d => d.SchoolLogo, o => o.MapFrom<LogoUrlResolver>()); 
            CreateMap<BaseSchoolName, CreateBaseSchoolNameDto>().ReverseMap();
            #endregion   


            #region Branch Mappings
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Branch, CreateBranchDto>().ReverseMap();
            #endregion

            #region Bulletin Mappings
            CreateMap<BulletinDto, Bulletin>().ReverseMap()
             .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName));
            CreateMap<Bulletin, CreateBulletinDto>().ReverseMap();
            #endregion

            #region InformationFezup Mappings
            CreateMap<InformationFezup, InformationFezupDto>().ReverseMap();
            CreateMap<InformationFezup, CreateInformationFezupDto>().ReverseMap();
            #endregion

            #region Area Mappings
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Area, CreateAreaDto>().ReverseMap();
            #endregion

            #region Base Mappings
            CreateMap<Base, BasemDto>().ReverseMap();
            CreateMap<Base, CreateBasemDto>().ReverseMap();
            #endregion

            #region SecurityQuestion Mappings
            CreateMap<SecurityQuestion, SecurityQuestionDto>().ReverseMap();
            CreateMap<SecurityQuestion, CreateSecurityQuestionDto>().ReverseMap();
            #endregion

            #region DemandBook Mappings
            CreateMap<DemandBook, DemandBookDto>().ReverseMap();
            CreateMap<DemandBook, CreateDemandBookDto>().ReverseMap();
            #endregion

            #region BookInformation Mappings
            CreateMap<BookInformationDto, BookInformation>().ReverseMap()
                .ForMember(d => d.BookCategory, o => o.MapFrom(s => s.BookCategory.BookCategoryName))
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookTitleInfo.BookTitleName + '-' + s.BookTitleInfo.TitleBangla))
                .ForMember(d => d.BookTitleEnglish, o => o.MapFrom(s => s.BookTitleInfo.BookTitleName))
                .ForMember(d => d.BookTitleBangla, o => o.MapFrom(s => s.BookTitleInfo.TitleBangla))
                .ForMember(d => d.MainClass, o => o.MapFrom(s => s.MainClass.Name))
                .ForMember(d => d.RowName, o => o.MapFrom(s => s.RowInfo.RowName))
                .ForMember(d => d.ShelfName, o => o.MapFrom(s => s.ShelfInfo.ShelfName))
                .ForMember(d => d.Language, o => o.MapFrom(s => s.Language.LanguageName))
                .ForMember(d => d.Source, o => o.MapFrom(s => s.Source.Name))
                .ForMember(d => d.CoverImage, o => o.MapFrom<PhotoUrlResolver>());
            CreateMap<BookInformation, CreateBookInformationDto>().ReverseMap();
            #endregion

            #region CourseType Mappings
            CreateMap<CourseType, CourseTypeDto>().ReverseMap();
            CreateMap<CourseType, CreateCourseTypeDto>().ReverseMap();
            #endregion

            #region InventoryType Mappings
            CreateMap<InventoryType, InventoryTypeDto>().ReverseMap();
            CreateMap<InventoryType, CreateInventoryTypeDto>().ReverseMap();
            #endregion 

            #region Inventory Mappings
            CreateMap<InventoryDto, Inventory >().ReverseMap()
                  .ForMember(d => d.InventoryType, o => o.MapFrom(s => s.InventoryType.Name));
            CreateMap<Inventory, CreateInventoryDto>().ReverseMap();
            #endregion

            #region FineForIssueReturn Mappings
            CreateMap<FineForIssueReturn, FineForIssueReturnDto>().ReverseMap();
            CreateMap<FineForIssueReturn, CreateFineForIssueReturnDto>().ReverseMap();
            #endregion

            #region BookBindingInfo Mappings
            CreateMap<BookBindingInfoDto, BookBindingInfo>().ReverseMap()
                .ForMember(d => d.BookTitleEnglish, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla))
                .ForMember(d => d.BookTitleBangla, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.TitleBangla))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.BookInformation.BookCategory.BookCategoryName))
                .ForMember(d => d.AccessionNo, o => o.MapFrom(s => s.BookInformation.AccessionNo));
            CreateMap<BookBindingInfo, CreateBookBindingInfoDto>().ReverseMap();
            #endregion

            #region BookTitleInfo Mappings
            CreateMap<BookTitleInfo, BookTitleInfoDto>().ReverseMap();
            CreateMap<BookTitleInfo, CreateBookTitleInfoDto>().ReverseMap();
            #endregion

            //#region BookCategory Mappings
            //CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
            //CreateMap<BookCategory, CreateBookCategoryDto>().ReverseMap();
            //#endregion

            #region BookCategory  Mappings  
            CreateMap<BookCategory, BookCategoryDto>().ReverseMap();
            CreateMap<BookCategory, CreateBookCategoryDto>().ReverseMap();
            #endregion

            #region DamageInformationByLibrary Mappings
            CreateMap<DamageInformationByLibraryDto, DamageInformationByLibrary>().ReverseMap()
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla))
                .ForMember(d => d.AccessionNo, o => o.MapFrom(s => s.BookInformation.AccessionNo));
            CreateMap<DamageInformationByLibrary, CreateDamageInformationByLibraryDto>().ReverseMap();
            #endregion

            #region DocumentTypes  Mappings  
            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentType, CreateDocumentTypeDto>().ReverseMap();
            #endregion

            #region FeeCategory Mappings
            CreateMap<FeeCategory, FeeCategoryDto>().ReverseMap();
            CreateMap<FeeCategory, CreateFeeCategoryDto>().ReverseMap();
            #endregion

           

            #region FeeInformation Mappings
            CreateMap<FeeInformationDto, FeeInformation>().ReverseMap()
                .ForMember(d => d.Pno, o => o.MapFrom(s => s.MemberInfo.PNO + '-' + s.MemberInfo.MemberName))
                .ForMember(d => d.Cagegory, o => o.MapFrom(s => s.FeeCategory.FeeCategoryName))
                .ForMember(d => d.AccessionNo, o => o.MapFrom(s => s.BookInformation.AccessionNo));
            CreateMap<FeeInformation, CreateFeeInformationDto>().ReverseMap();
            #endregion

            #region ReaderInformation Mappings
            CreateMap<ReaderInformationDto, ReaderInformation>().ReverseMap()
                .ForMember(d => d.Pno, o => o.MapFrom(s => s.MemberInfo.PNO));
            CreateMap<ReaderInformation, CreateReaderInformationDto>().ReverseMap();
            #endregion

            #region OnlineBookRequest Mappings
            CreateMap<OnlineBookRequestDto, OnlineBookRequest>().ReverseMap()
                .ForMember(d => d.BookInformation, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.ShortName))
                .ForMember(d => d.MemberInfo, o => o.MapFrom(s => s.MemberInfo.PNO + '-' + s.MemberInfo.MemberName));
            CreateMap<OnlineBookRequest, CreateOnlineBookRequestDto>().ReverseMap();
            #endregion

            #region Language Mappings
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            #endregion

            #region MainClass Mappings
            CreateMap<MainClass, MainClassDto>().ReverseMap();
            CreateMap<MainClass, CreateMainClassDto>().ReverseMap();
            #endregion

            #region MemberCategory Mappings
            CreateMap<MemberCategory, MemberCategoryDto>().ReverseMap();
            CreateMap<MemberCategory, CreateMemberCategoryDto>().ReverseMap();
            #endregion

            #region Notification Mappings
            CreateMap<OnlineChat, OnlineChatDto>().ReverseMap();
            CreateMap<OnlineChat, CreateOnlineChatDto>().ReverseMap();
            #endregion

            #region PublishersInformation Mappings
            CreateMap<PublishersInformationDto, PublishersInformation>().ReverseMap()
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla));
            CreateMap<PublishersInformation, CreatePublishersInformationDto>().ReverseMap();
            #endregion

            #region Source Mappings
            CreateMap<Source, SourceDto>().ReverseMap();
            CreateMap<Source, CreateSourceDto>().ReverseMap();
            #endregion

            #region EventInfo Mappings
            CreateMap<EventInfo, EventInfoDto>().ReverseMap();
            CreateMap<EventInfo, CreateEventInfoDto>().ReverseMap();
            #endregion

            #region NoticeInfo Mappings
            CreateMap<NoticeInfoDto, NoticeInfo>().ReverseMap()
                 .ForMember(d => d.NoticeType, o => o.MapFrom(s => s.NoticeType.Name))
                 .ForMember(d => d.UploadPDFFile, o => o.MapFrom<NoticeInfoFileUrlResolver>());
            CreateMap<NoticeInfo, CreateNoticeInfoDto>().ReverseMap();
            #endregion

            #region NoticeType Mappings
            CreateMap<NoticeType, NoticeTypeDto>().ReverseMap();
            CreateMap<NoticeType, CreateNoticeTypeDto>().ReverseMap();
            #endregion

            #region SoftCopyUpload Mappings
            CreateMap<SoftCopyUploadDto, SoftCopyUpload>().ReverseMap()
                 .ForMember(d => d.DocumentType, o => o.MapFrom(s => s.DocumentType.IconName))
                 .ForMember(d => d.StorePDFFile, o => o.MapFrom<SoftCopyUploadFileUrlResolver>());

            CreateMap<SoftCopyUpload, CreateSoftCopyUploadDto>().ReverseMap();
            #endregion

            #region RowInfo Mappings
            CreateMap<RowInfoDto, RowInfo>().ReverseMap()
                 .ForMember(d => d.ShelfName, o => o.MapFrom(s => s.ShelfInfo.ShelfName));
            CreateMap<RowInfo, CreateRowInfoDto>().ReverseMap();
            #endregion

            #region VideoFile Mappings    
            CreateMap<VideoFileDto, VideoFile>().ReverseMap()
                //.ForMember(d => d.CourseName, o => o.MapFrom(s => s.CourseName.Course))
                //.ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                //.ForMember(d => d.DocumentType, o => o.MapFrom(s => s.DocumentType.DocumentTypeName))
                //.ForMember(d => d.DownloadRight, o => o.MapFrom(s => s.DownloadRight.DownloadRightName))
                //.ForMember(d => d.ShowRight, o => o.MapFrom(s => s.ShowRight.SchoolName))
                //.ForMember(d => d.VideoFileTitle, o => o.MapFrom(s => s.VideoFileTitle.Title))
                //.ForMember(d => d.DocumentIcon, o => o.MapFrom(s => s.DocumentType.IconName))
                .ForMember(d => d.DocumentLink, o => o.MapFrom<FileUrlResolver>());

            CreateMap<VideoFile, CreateVideoFileDto>().ReverseMap();
            #endregion

            #region ShelfInfo Mappings
            CreateMap<ShelfInfo, ShelfInfoDto>().ReverseMap();
            CreateMap<ShelfInfo, CreateShelfInfoDto>().ReverseMap();
            #endregion

            #region BookIssueAndSubmission Mappings
            //CreateMap<BookIssueAndSubmission, BookIssueAndSubmissionDto>().ReverseMap();
            CreateMap<BookIssueAndSubmissionDto, BookIssueAndSubmission>().ReverseMap()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.BaseSchoolName.ShortName))
                .ForMember(d => d.Pno, o => o.MapFrom(s => s.MemberInfo.PNO + '-' + s.MemberInfo.MemberName))
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.BookInformation.BookCategory.BookCategoryName))
                //.ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                //.ForMember(d => d.BookInformation, o => o.MapFrom(s => s.BookInformation.BookTitleInfo))
                //.ForMember(d => d.MemberInfo, o => o.MapFrom(s => s.MemberInfo.MemberName))
                //.ForMember(d => d.RowInfo, o => o.MapFrom(s => s.RowInfo.RowName))
                //.ForMember(d => d.ShelfInfo, o => o.MapFrom(s => s.ShelfInfo.ShelfName))
                .ForMember(d => d.AccessionNo, o => o.MapFrom(s => s.BookInformation.MergeId))
                .ForMember(d => d.BookTitleBangla, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.TitleBangla));
            CreateMap<BookIssueAndSubmission, CreateBookIssueAndSubmissionDto>().ReverseMap();
            #endregion

            #region MemberRegistration Mappings
            CreateMap<MemberRegistration, MemberRegistrationDto>().ReverseMap();
            CreateMap<MemberRegistration, CreateMemberRegistrationDto>().ReverseMap();
            #endregion


            #region JobStatus Mappings
            CreateMap<JobStatus, JobStatusDto>().ReverseMap();
            CreateMap<JobStatus, CreateJobStatusDto>().ReverseMap();
            #endregion

            #region Designation Mappings
            CreateMap<Designation, DesignationDto>().ReverseMap();
            CreateMap<Designation, CreateDesignationDto>().ReverseMap();
            #endregion

            #region Rank Mappings
            CreateMap<RankDto, Rank>().ReverseMap()
                 .ForMember(d => d.Designation, o => o.MapFrom(s => s.Designation.DesignationName));
            CreateMap<Rank, CreateRankDto>().ReverseMap();
            #endregion

            #region MemberInfo Mappings
            CreateMap<MemberInfoDto, MemberInfo>().ReverseMap()
                .ForMember(d => d.MemberCategory, o => o.MapFrom(s => s.MemberCategory.MemberCategoryName))
                .ForMember(d => d.BaseSchoolName, o => o.MapFrom(s => s.BaseSchoolName.SchoolName))
                .ForMember(d => d.Rank, o => o.MapFrom(s => s.Rank.RankName))
                .ForMember(d => d.Designation, o => o.MapFrom(s => s.Designation.DesignationName))
                .ForMember(d => d.JobStatus, o => o.MapFrom(s => s.JobStatus.JobStatusName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<MemberPhotoUrlResolver>());
            CreateMap<MemberInfo, CreateMemberInfoDto>().ReverseMap();
            #endregion

            #region Features Mapping    
            CreateMap<FeatureDto, Feature>().ReverseMap()
             .ForMember(d => d.ModuleName, o => o.MapFrom(s => s.Module.Title));

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            #endregion

            #region Modules Mapping    
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<Module, ModuleFeatureDto>().ReverseMap();

            CreateMap<Module, CreateModuleDto>().ReverseMap();
            #endregion


            #region RoleFeature Mappings 
            CreateMap<RoleFeature, RoleFeatureDto>().ReverseMap();
            CreateMap<RoleFeature, CreateRoleFeatureDto>().ReverseMap();
            #endregion

            #region SourceInformation Mappings
            CreateMap<SourceInformationDto, SourceInformation>().ReverseMap()
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla));
            CreateMap<SourceInformation, CreateSourceInformationDto>().ReverseMap();
            #endregion

            #region SupplierInformation Mappings
            CreateMap<SupplierInformationDto, SupplierInformation>().ReverseMap()
                .ForMember(d => d.BookTitle, o => o.MapFrom(s => s.BookInformation.BookTitleInfo.BookTitleName + '-' + s.BookInformation.BookTitleInfo.TitleBangla));
            CreateMap<SupplierInformation, CreateSupplierInformationDto>().ReverseMap();
            #endregion

            #region LibraryAuthority Mappings 
            CreateMap<LibraryAuthority, LibraryAuthorityDto>().ReverseMap();
            CreateMap<LibraryAuthority, CreateLibraryAuthorityDto>().ReverseMap();
            #endregion


        }
    }

}
