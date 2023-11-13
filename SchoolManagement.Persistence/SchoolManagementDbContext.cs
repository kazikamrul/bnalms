using SchoolManagement.Domain;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace SchoolManagement.Persistence
{
    public class SchoolManagementDbContext : AuditableDbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AuthorInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorInformation_BookInformation");

                entity.HasOne(d => d.AuthorityCategory)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.AuthorityCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorInformation_AuthorityCategory");

            });

            modelBuilder.Entity<AuthorityCategory>(entity =>
            {

            });


            modelBuilder.Entity<BaseName>(entity =>
            {
            });

            modelBuilder.Entity<HelpLine>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                  .WithMany(p => p.HelpLines)
                  .HasForeignKey(d => d.BaseSchoolNameId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_HelpLine_BaseSchoolName");

                entity.HasOne(d => d.LibraryAuthority)
                 .WithMany(p => p.HelpLines)
                 .HasForeignKey(d => d.LibraryAuthorityId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_HelpLine_LibraryAuthority");
            });

            modelBuilder.Entity<BaseSchoolName>(entity =>
            {

                entity.HasOne(d => d.BaseName)
                    .WithMany(p => p.BaseSchoolNames)
                    .HasForeignKey(d => d.BaseNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BaseSchoolName_BaseName");

            });



            modelBuilder.Entity<Branch>(entity =>
            {

            });

            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                   .WithMany(p => p.Bulletins)
                   .HasForeignKey(d => d.BaseSchoolNameId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Bulletin_BaseSchoolName");

            });

            modelBuilder.Entity<InformationFezup>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                   .WithMany(p => p.InformationFezups)
                   .HasForeignKey(d => d.BaseSchoolNameId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_InformationFezup_BaseSchoolName");

            });

            modelBuilder.Entity<BookBindingInfo>(entity =>
            {

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookBindingInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookBindingInfo_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.BookBindingInfos)
                    .HasForeignKey(d => d.BookInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookBindingInfo_BookInformation");

            });

            modelBuilder.Entity<BookInformation>(entity =>
            {

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_BaseSchoolName");

                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BookCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_BookCategory");

                entity.HasOne(d => d.BookTitleInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BookTitleInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_BookTitleInfo");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_Language");

                entity.HasOne(d => d.MainClass)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.MainClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_MainClass");

                entity.HasOne(d => d.RowInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.RowInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_RowInfo");

                entity.HasOne(d => d.ShelfInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.ShelfInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookInformation_ShelfInfo");

            });

            modelBuilder.Entity<BookIssueAndSubmission>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookIssueAndSubmissions)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BookIssueAndSubmission_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.BookIssueAndSubmissions)
                    .HasForeignKey(d => d.BookInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookIssueAndSubmission_BookInformation");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.BookIssueAndSubmissions)
                    .HasForeignKey(d => d.MemberInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookIssueAndSubmission_MemberInfo");

                entity.HasOne(d => d.RowInfo)
                .WithMany(p => p.BookIssueAndSubmissions)
                .HasForeignKey(d => d.RowInfoId)
                .HasConstraintName("FK_BookIssueAndSubmission_RowInfo");

                entity.HasOne(d => d.ShelfInfo)
                    .WithMany(p => p.BookIssueAndSubmissions)
                    .HasForeignKey(d => d.ShelfInfoId)
                    .HasConstraintName("FK_BookIssueAndSubmission_ShelfInfo");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {

            });

            modelBuilder.Entity<DemandBook>(entity =>
            {

            });

            modelBuilder.Entity<DamageInformationByLibrary>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                   .WithMany(p => p.DamageInformationByLibraries)
                   .HasForeignKey(d => d.BaseSchoolNameId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_DamageInformationByLibrary_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                  .WithMany(p => p.DamageInformationByLibraries)
                  .HasForeignKey(d => d.BookInformationId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_DamageInformationByLibrary_BookInformation");

            });

            modelBuilder.Entity<JobStatus>(entity =>
            {

            });

            modelBuilder.Entity<FeeCategory>(entity =>
            {

            });
            

            modelBuilder.Entity<EventInfo>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.EventInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_EventInfo_BaseSchoolName");
            });
            modelBuilder.Entity<FeeInformation>(entity =>
            {

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeInformation_BaseSchoolName");

                entity.HasOne(d => d.FeeCategory)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.FeeCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeInformation_FeeCategory");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.MemberInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeInformation_MemberInfo");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FeeInformation_BookInformation");

            });

            modelBuilder.Entity<FileInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                   .WithMany(p => p.FileInformations)
                   .HasForeignKey(d => d.BaseSchoolNameId)
                   .HasConstraintName("FK_FileInformation_BaseSchoolName");

            });

            modelBuilder.Entity<Designation>(entity =>
            {

            });
            modelBuilder.Entity<DocumentType>(entity =>
            {
            
            });
            modelBuilder.Entity<BookCategory>(entity =>
            {

            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rank_Designation");

            });

            modelBuilder.Entity<Language>(entity =>
            {

            });

            modelBuilder.Entity<MainClass>(entity =>
            {

            });

            modelBuilder.Entity<Area>(entity =>
            {

            });

            modelBuilder.Entity<Base>(entity =>
            {

            });

            modelBuilder.Entity<SecurityQuestion>(entity =>
            {

            });

            modelBuilder.Entity<MemberInfo>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.BookInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_BookInformation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_Designation");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.JobStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_JobStatus");

                entity.HasOne(d => d.Area)
                   .WithMany(p => p.MemberInfos)
                   .HasForeignKey(d => d.AreaId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberInfo_Area");

                entity.HasOne(d => d.Base)
                   .WithMany(p => p.MemberInfos)
                   .HasForeignKey(d => d.BaseId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberInfo_Base");

                entity.HasOne(d => d.SecurityQuestion)
                   .WithMany(p => p.MemberInfos)
                   .HasForeignKey(d => d.SecurityQuestionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberInfo_SecurityQuestion");

                entity.HasOne(d => d.MemberCategory)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.MemberCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_MemberCategory");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInfo_Rank");

            });

            modelBuilder.Entity<MemberRegistration>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRegistration_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                   .WithMany(p => p.MemberRegistrations)
                   .HasForeignKey(d => d.BookInformationId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberRegistration_BookInformation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRegistration_Designation");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.JobStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRegistration_JobStatus");

                entity.HasOne(d => d.Area)
                   .WithMany(p => p.MemberRegistrations)
                   .HasForeignKey(d => d.AreaId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberRegistration_Area");

                entity.HasOne(d => d.Base)
                   .WithMany(p => p.MemberRegistrations)
                   .HasForeignKey(d => d.BaseId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberRegistration_Base");


                entity.HasOne(d => d.MemberCategory)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.MemberCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRegistration_MemberCategory");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberRegistration_Rank");

                entity.HasOne(d => d.SecurityQuestion)
                   .WithMany(p => p.MemberRegistrations)
                   .HasForeignKey(d => d.SecurityQuestionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_MemberRegistration_SecurityQuestion");

            });

            modelBuilder.Entity<PublishersInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.PublishersInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PublishersInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                   .WithMany(p => p.PublishersInformations)
                   .HasForeignKey(d => d.BookInformationId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_PublishersInformation_BookInformation");
            });

            modelBuilder.Entity<OnlineChat>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                  .WithMany(p => p.OnlineChats)
                  .HasForeignKey(d => d.SendBaseSchoolNameId)
                  .HasConstraintName("FK_OnlineChat_BaseSchoolName");

                entity.HasOne(d => d.BaseSchoolName)
                  .WithMany(p => p.OnlineChats)
                  .HasForeignKey(d => d.ReceivedBaseSchoolNameId)
                  .HasConstraintName("FK_OnlineChat_BaseSchoolName1");

            });

            modelBuilder.Entity<ShelfInfo>(entity =>
            {

            });
            modelBuilder.Entity<RowInfo>(entity =>
            {
                entity.HasOne(d => d.ShelfInfo)
                    .WithMany(p => p.RowInfos)
                    .HasForeignKey(d => d.ShelfInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RowInfo_ShelfInfo");

            });
            modelBuilder.Entity<ReaderInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.ReaderInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReaderInformation_BaseSchoolName");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.ReaderInformations)
                    .HasForeignKey(d => d.MemberInfoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReaderInformation_MemberInfo");

            });

            modelBuilder.Entity<Source>(entity =>
            {

            });

            modelBuilder.Entity<SoftCopyUpload>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SoftCopyUploads)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SoftCopyUpload_BaseSchoolName");

                entity.HasOne(d => d.DocumentType)
                .WithMany(p => p.SoftCopyUploads)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK_SoftCopyUpload_DocumentType");

            });

            modelBuilder.Entity<BookTitleInfo>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookTitleInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookTitleInfo_BaseSchoolName");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_Module");
            });


            modelBuilder.Entity<Module>(entity =>
            {

            });

            modelBuilder.Entity<NoticeInfo>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.NoticeInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoticeInfo_BaseSchoolName");

                entity.HasOne(d => d.NoticeType)
                    .WithMany(p => p.NoticeInfos)
                    .HasForeignKey(d => d.NoticeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NoticeInfo_NoticeType");

            });

            modelBuilder.Entity<OnlineBookRequest>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                .WithMany(p => p.OnlineBookRequests)
                .HasForeignKey(d => d.BaseSchoolNameId)
                .HasConstraintName("FK_OnlineBookRequest_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.OnlineBookRequests)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_OnlineBookRequest_BookInformation");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.OnlineBookRequests)
                    .HasForeignKey(d => d.MemberInfoId)
                    .HasConstraintName("FK_OnlineBookRequest_MemberInfo");
            });

            modelBuilder.Entity<NoticeType>(entity =>
            {

            });


            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FeatureKey });

                entity.ToTable("RoleFeature");


            });
            modelBuilder.Entity<MemberCategory>(entity =>
            {

            });

            modelBuilder.Entity<SupplierInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SupplierInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SupplierInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                   .WithMany(p => p.SupplierInformations)
                   .HasForeignKey(d => d.BookInformationId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_SupplierInformation_BookInformation");

            });

            modelBuilder.Entity<SourceInformation>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SourceInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SourceInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                   .WithMany(p => p.SourceInformations)
                   .HasForeignKey(d => d.BookInformationId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_SourceInformation_BookInformation");

            });

            modelBuilder.Entity<VideoFile>(entity =>
            {
             
            });

            modelBuilder.Entity<LibraryAuthority>(entity =>
            {

            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_BaseSchoolName");

                entity.HasOne(d => d.InventoryType)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_InventoryType");
            });

            modelBuilder.Entity<InventoryType>(entity =>
            {
            
            });
            modelBuilder.Entity<FineForIssueReturn>(entity =>
            {
                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.FineForIssueReturns)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_FineForIssueReturn_FineForIssueReturn");
            });

        }


        public virtual DbSet<AuthorInformation> AuthorInformation { get; set; } = null!;
        public virtual DbSet<AuthorityCategory> AuthorityCategory { get; set; } = null!;
        public virtual DbSet<BaseName> BaseName { get; set; } = null!;
        public virtual DbSet<BaseSchoolName> BaseSchoolName { get; set; } = null!;
        public virtual DbSet<Branch> Branch { get; set; } = null!;
        public virtual DbSet<Bulletin> Bulletin { get; set; } = null!;
        public virtual DbSet<InformationFezup> InformationFezup { get; set; } = null!;
        public virtual DbSet<BookBindingInfo> BookBindingInfo { get; set; } = null!;
        public virtual DbSet<BookInformation> BookInformation { get; set; } = null!;
        public virtual DbSet<BookIssueAndSubmission> BookIssueAndSubmission { get; set; }
        public virtual DbSet<CourseType> CourseType { get; set; } = null!;
        public virtual DbSet<DamageInformationByLibrary> DamageInformationByLibrary { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentType { get; set; } = null!;
        public virtual DbSet<EventInfo> EventInfo { get; set; } 
        public virtual DbSet<FeeCategory> FeeCategory { get; set; } = null!;
        public virtual DbSet<FeeInformation> FeeInformation { get; set; } = null!;
        public virtual DbSet<FileInformation> FileInformation { get; set; } = null!;
        public virtual DbSet<BookTitleInfo> BookTitleInfo { get; set; } = null!;
        public virtual DbSet<BookCategory> BookCategory { get; set; } = null!;
        public virtual DbSet<Language> Language { get; set; } = null!;
        public virtual DbSet<MainClass> MainClass { get; set; } = null!;
        public virtual DbSet<HelpLine> HelpLine { get; set; } = null!;
        public virtual DbSet<OnlineBookRequest> OnlineBookRequest { get; set; } = null!;
        public virtual DbSet<RowInfo> RowInfo { get; set; } = null!;
        public virtual DbSet<ReaderInformation> ReaderInformation { get; set; } = null!;
        public virtual DbSet<Source> Source { get; set; } = null!;
        public virtual DbSet<SoftCopyUpload> SoftCopyUpload { get; set; } = null!;
        public virtual DbSet<ShelfInfo> ShelfInfo { get; set; } = null!;
        public virtual DbSet<Feature> Feature { get; set; } = null!;
        public virtual DbSet<Module> Module { get; set; } = null!;
        public virtual DbSet<RoleFeature> RoleFeature { get; set; } = null!;
        public virtual DbSet<MemberCategory> MemberCategory { get; set; }
        public virtual DbSet<MemberInfo> MemberInfo { get; set; }
        public virtual DbSet<MemberRegistration> MemberRegistration { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Base> Base { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        public virtual DbSet<DemandBook> DemandBook { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<PublishersInformation> PublishersInformation { get; set; }
        public virtual DbSet<SourceInformation> SourceInformation { get; set; }
        public virtual DbSet<SupplierInformation> SupplierInformation { get; set; }
        public virtual DbSet<VideoFile> VideoFiles { get; set; }
        public virtual DbSet<LibraryAuthority> LibraryAuthority { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; } 
        public virtual DbSet<InventoryType> InventoryType { get; set; }
        public virtual DbSet<FineForIssueReturn> FineForIssueReturn { get; set; }
    }
}
