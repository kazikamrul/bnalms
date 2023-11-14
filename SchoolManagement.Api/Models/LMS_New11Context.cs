using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagement.Api.Models
{
    public partial class LMS_New11Context : DbContext
    {
        public LMS_New11Context()
        {
        }

        public LMS_New11Context(DbContextOptions<LMS_New11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountInformation> AccountInformations { get; set; }
        public virtual DbSet<AllBookInfo> AllBookInfos { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<AuthorInfoSingleLine> AuthorInfoSingleLines { get; set; }
        public virtual DbSet<AuthorInformation> AuthorInformations { get; set; }
        public virtual DbSet<AuthorityCategory> AuthorityCategories { get; set; }
        public virtual DbSet<BankInfo> BankInfos { get; set; }
        public virtual DbSet<Base> Bases { get; set; }
        public virtual DbSet<BaseName> BaseNames { get; set; }
        public virtual DbSet<BaseSchoolName> BaseSchoolNames { get; set; }
        public virtual DbSet<BookBindingInfo> BookBindingInfos { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<BookInformation> BookInformations { get; set; }
        public virtual DbSet<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual DbSet<BookSelfInfo> BookSelfInfos { get; set; }
        public virtual DbSet<BookTitleInfo> BookTitleInfos { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BranchInfo> BranchInfos { get; set; }
        public virtual DbSet<Bulletin> Bulletins { get; set; }
        public virtual DbSet<CategoryLimit> CategoryLimits { get; set; }
        public virtual DbSet<CommonCode> CommonCodes { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<DamageInformationByLibrary> DamageInformationByLibraries { get; set; }
        public virtual DbSet<DemandBook> DemandBooks { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<DonorInformation> DonorInformations { get; set; }
        public virtual DbSet<EventInfo> EventInfos { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FeeCategory> FeeCategories { get; set; }
        public virtual DbSet<FeeInformation> FeeInformations { get; set; }
        public virtual DbSet<FeeSetup> FeeSetups { get; set; }
        public virtual DbSet<FileInformation> FileInformations { get; set; }
        public virtual DbSet<FineForIssueReturn> FineForIssueReturns { get; set; }
        public virtual DbSet<HelpLine> HelpLines { get; set; }
        public virtual DbSet<InformationFezup> InformationFezups { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryType> InventoryTypes { get; set; }
        public virtual DbSet<JobStatus> JobStatuses { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LibraryAuthority> LibraryAuthorities { get; set; }
        public virtual DbSet<MainClass> MainClasses { get; set; }
        public virtual DbSet<MemberCategory> MemberCategories { get; set; }
        public virtual DbSet<MemberInfo> MemberInfos { get; set; }
        public virtual DbSet<MemberOfficialInfo> MemberOfficialInfos { get; set; }
        public virtual DbSet<MemberRegistration> MemberRegistrations { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<NoticeInfo> NoticeInfos { get; set; }
        public virtual DbSet<NoticeType> NoticeTypes { get; set; }
        public virtual DbSet<OnlineBookRequest> OnlineBookRequests { get; set; }
        public virtual DbSet<OnlineChat> OnlineChats { get; set; }
        public virtual DbSet<PublishersInformation> PublishersInformations { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<ReaderInformation> ReaderInformations { get; set; }
        public virtual DbSet<RegistrationQueueInfo> RegistrationQueueInfos { get; set; }
        public virtual DbSet<RegistrationQueueInfo1> RegistrationQueueInfoes { get; set; }
        public virtual DbSet<Reporting> Reportings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFeature> RoleFeatures { get; set; }
        public virtual DbSet<RowInfo> RowInfos { get; set; }
        public virtual DbSet<SecurityQuestion> SecurityQuestions { get; set; }
        public virtual DbSet<SelfControlInfo> SelfControlInfos { get; set; }
        public virtual DbSet<ShelfInfo> ShelfInfos { get; set; }
        public virtual DbSet<SoftCopyUpload> SoftCopyUploads { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<SourceInformation> SourceInformations { get; set; }
        public virtual DbSet<SupplierInformation> SupplierInformations { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Test2> Test2s { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBankInfoMvc> UserBankInfoMvcs { get; set; }
        public virtual DbSet<UserLogInfo> UserLogInfos { get; set; }
        public virtual DbSet<UserUrlright> UserUrlrights { get; set; }
        public virtual DbSet<VAccountInfo> VAccountInfos { get; set; }
        public virtual DbSet<VideoFile> VideoFiles { get; set; }
        public virtual DbSet<ZoneInfo> ZoneInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=114.134.95.235,1434;Database=LMS_New-11;user id=sa;password=B@ngl@d3sh;Trusted_Connection=false;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountInformation>(entity =>
            {
                entity.HasKey(e => e.AccountInformationIdentity);

                entity.ToTable("AccountInformation");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountHead)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AccountLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountStatusCode).HasDefaultValueSql("('00')");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FifthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FourthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("smalldatetime");

                entity.Property(e => e.SecondLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AllBookInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AllBookInfo");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BookCategory)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BookSubtitle)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.BookTitleName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CallNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DonationDate).HasColumnType("datetime");

                entity.Property(e => e.DonorAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DonorEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonorName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Heading)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Issn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ISSN");

                entity.Property(e => e.Language)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherPlace)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PublishersAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PublishersName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.SelfNo).HasMaxLength(500);

                entity.Property(e => e.SelfRowNo).HasMaxLength(500);

                entity.Property(e => e.SuppliedDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TitleBangla).HasMaxLength(200);

                entity.Property(e => e.TitleCategory)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.BranchId).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.InActiveDate).HasColumnType("datetime");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Pno).HasColumnName("PNo");

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AuthorInfoSingleLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AuthorInfoSingleLine");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Row).HasColumnName("ROW");

                entity.Property(e => e.TypeValue)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AuthorInformation>(entity =>
            {
                entity.ToTable("AuthorInformation");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.AuthorityCategory)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.AuthorityCategoryId)
                    .HasConstraintName("FK_AuthorInformation_AuthorityCategory");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_AuthorInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.AuthorInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_AuthorInformation_BookInformation");
            });

            modelBuilder.Entity<AuthorityCategory>(entity =>
            {
                entity.ToTable("AuthorityCategory");

                entity.Property(e => e.AuthorCategoryName).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BankInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("BankInfo");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchAddress)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NativeBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NativeBranchName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoutingNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubBranchCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubBranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Base>(entity =>
            {
                entity.ToTable("Base");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<BaseName>(entity =>
            {
                entity.ToTable("BaseName");

                entity.Property(e => e.BaseLogo).HasMaxLength(450);

                entity.Property(e => e.BaseNames)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);
            });

            modelBuilder.Entity<BaseSchoolName>(entity =>
            {
                entity.ToTable("BaseSchoolName");

                entity.Property(e => e.Address)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.SchoolLogo).HasMaxLength(450);

                entity.Property(e => e.SchoolName).HasMaxLength(450);

                entity.Property(e => e.ServerName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName).HasMaxLength(450);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookBindingInfo>(entity =>
            {
                entity.ToTable("BookBindingInfo");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OfficeDispiseNumber).HasMaxLength(450);

                entity.Property(e => e.PressAddress).HasMaxLength(450);

                entity.Property(e => e.PressEmail).HasMaxLength(450);

                entity.Property(e => e.PressName).HasMaxLength(450);

                entity.Property(e => e.ReceivedOfficerName).HasMaxLength(450);

                entity.Property(e => e.SenderOfficer).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookBindingInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BookBindingInfo_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.BookBindingInfos)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_BookBindingInfo_BookInformation");
            });

            modelBuilder.Entity<BookCategory>(entity =>
            {
                entity.ToTable("BookCategory");

                entity.Property(e => e.BookCategoryName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BookInformation>(entity =>
            {
                entity.ToTable("BookInformation");

                entity.Property(e => e.AccessionDate).HasColumnType("datetime");

                entity.Property(e => e.AccessionNo).HasMaxLength(450);

                entity.Property(e => e.BorrowerDamageDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerDamageRemarks).HasMaxLength(450);

                entity.Property(e => e.CoverImage).HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DamageDate).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Edition).HasMaxLength(450);

                entity.Property(e => e.Heading).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MergeId).HasMaxLength(450);

                entity.Property(e => e.Notes).HasMaxLength(450);

                entity.Property(e => e.Reason).HasMaxLength(1000);

                entity.Property(e => e.UseableDays).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BookInformation_BaseSchoolName");

                entity.HasOne(d => d.BookCategory)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BookCategoryId)
                    .HasConstraintName("FK_BookInformation_BookCategory");

                entity.HasOne(d => d.BookTitleInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.BookTitleInfoId)
                    .HasConstraintName("FK_BookInformation_BookTitleInfo");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_BookInformation_Language");

                entity.HasOne(d => d.MainClass)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.MainClassId)
                    .HasConstraintName("FK_BookInformation_MainClass");

                entity.HasOne(d => d.RowInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.RowInfoId)
                    .HasConstraintName("FK_BookInformation_RowInfo");

                entity.HasOne(d => d.ShelfInfo)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.ShelfInfoId)
                    .HasConstraintName("FK_BookInformation_ShelfInfo");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.BookInformations)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK_BookInformation_Source");
            });

            modelBuilder.Entity<BookIssueAndSubmission>(entity =>
            {
                entity.ToTable("BookIssueAndSubmission");

                entity.Property(e => e.AcceptDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerDamageDate).HasColumnType("datetime");

                entity.Property(e => e.BorrowerDamageRemarks).HasMaxLength(450);

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CancelId).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IsDamage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssuedBy).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RemarksForIssue).HasMaxLength(450);

                entity.Property(e => e.RemarksForSubmission).HasMaxLength(450);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");

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

            modelBuilder.Entity<BookSelfInfo>(entity =>
            {
                entity.HasKey(e => e.BookSelfIdentity);

                entity.ToTable("BookSelfInfo");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Level1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Level2)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Level3)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookTitleInfo>(entity =>
            {
                entity.ToTable("BookTitleInfo");

                entity.Property(e => e.BookSubtitle).HasMaxLength(450);

                entity.Property(e => e.BookTitleName).HasMaxLength(450);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.TitleBangla).HasMaxLength(450);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.BookTitleInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_BookTitleInfo_BaseSchoolName");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShortName).HasMaxLength(450);
            });

            modelBuilder.Entity<BranchInfo>(entity =>
            {
                entity.HasKey(e => e.BranchCode)
                    .HasName("PK_BranchInfo_1");

                entity.ToTable("BranchInfo");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNoFc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountNoFC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccountNoLc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountNoLC")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.BranchLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')")
                    .IsFixedLength();

                entity.Property(e => e.Cellphone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('BD')");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('BDT')");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FifthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FourthLevel)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NativeBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OwnBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdLevel)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000')")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.ToTable("Bulletin");

                entity.Property(e => e.BuletinDetails).HasMaxLength(4000);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.Bulletins)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_Bulletin_BaseSchoolName");
            });

            modelBuilder.Entity<CategoryLimit>(entity =>
            {
                entity.ToTable("CategoryLimit");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CommonCode>(entity =>
            {
                entity.ToTable("CommonCode");

                entity.HasIndex(e => new { e.BankCode, e.Type }, "IX_CommonCode_Type");

                entity.Property(e => e.CommonCodeId).HasColumnName("CommonCodeID");

                entity.Property(e => e.AdditonalValue)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((11))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate).HasColumnType("smalldatetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeValue)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.ToTable("CourseType");

                entity.Property(e => e.CourseTypeName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DamageInformationByLibrary>(entity =>
            {
                entity.ToTable("DamageInformationByLibrary");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DamageBy).HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(500);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.DamageInformationByLibraries)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_DamageInformationByLibrary_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.DamageInformationByLibraries)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_DamageInformationByLibrary_BookInformation");
            });

            modelBuilder.Entity<DemandBook>(entity =>
            {
                entity.ToTable("DemandBook");

                entity.Property(e => e.AuthorName).HasMaxLength(450);

                entity.Property(e => e.BookName).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.ToTable("Designation");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DesignationName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DocumentTypeName).HasMaxLength(450);

                entity.Property(e => e.IconName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DonorInformation>(entity =>
            {
                entity.HasKey(e => e.DonorId);

                entity.ToTable("DonorInformation");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonationDate).HasColumnType("datetime");

                entity.Property(e => e.DonorAddress)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DonorEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonorName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventInfo>(entity =>
            {
                entity.ToTable("EventInfo");

                entity.Property(e => e.ApprovedName).HasMaxLength(450);

                entity.Property(e => e.BudgetDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EventCharge).HasMaxLength(450);

                entity.Property(e => e.EventFrom).HasColumnType("datetime");

                entity.Property(e => e.EventLocation).HasMaxLength(450);

                entity.Property(e => e.EventName).HasMaxLength(450);

                entity.Property(e => e.EventPurpose).HasMaxLength(450);

                entity.Property(e => e.EventSubject).HasMaxLength(450);

                entity.Property(e => e.EventTo).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.EventInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_EventInfo_BaseSchoolName");
            });

            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.HasKey(e => e.Slno);

                entity.ToTable("EventLog");

                entity.Property(e => e.Slno).HasColumnName("SLNo");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentInfo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EventTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PreviousInfo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Workstation)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("Feature");

                entity.Property(e => e.Class).HasMaxLength(250);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FeatureName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.GroupTitle).HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.IconName).HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feature_Module");
            });

            modelBuilder.Entity<FeeCategory>(entity =>
            {
                entity.ToTable("FeeCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FeeCategoryName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FeeInformation>(entity =>
            {
                entity.ToTable("FeeInformation");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.ReceivedAmount)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_FeeInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_FeeInformation_BookInformation");

                entity.HasOne(d => d.FeeCategory)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.FeeCategoryId)
                    .HasConstraintName("FK_FeeInformation_FeeCategory");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.FeeInformations)
                    .HasForeignKey(d => d.MemberInfoId)
                    .HasConstraintName("FK_FeeInformation_MemberInfo");
            });

            modelBuilder.Entity<FeeSetup>(entity =>
            {
                entity.HasKey(e => e.FeeSetupIdentity);

                entity.ToTable("FeeSetup");

                entity.Property(e => e.FeeCategory)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FileInformation>(entity =>
            {
                entity.ToTable("FileInformation");

                entity.Property(e => e.Author).HasMaxLength(450);

                entity.Property(e => e.BooksTitle).HasMaxLength(450);

                entity.Property(e => e.BooksUrl).HasMaxLength(450);

                entity.Property(e => e.CorporateAuthor).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Editor).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.FileInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_FileInformation_BaseSchoolName");
            });

            

            modelBuilder.Entity<HelpLine>(entity =>
            {
                entity.ToTable("HelpLine");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.HelpContact).HasMaxLength(50);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.HelpLines)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_HelpLine_BaseSchoolName");

                entity.HasOne(d => d.LibraryAuthority)
                    .WithMany(p => p.HelpLines)
                    .HasForeignKey(d => d.LibraryAuthorityId)
                    .HasConstraintName("FK_HelpLine_LibraryAuthority");
            });

            modelBuilder.Entity<InformationFezup>(entity =>
            {
                entity.ToTable("InformationFezup");

                entity.Property(e => e.Category).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(450);

                entity.Property(e => e.Designation).HasMaxLength(450);

                entity.Property(e => e.Email).HasMaxLength(450);

                entity.Property(e => e.FatherName).HasMaxLength(450);

                entity.Property(e => e.JobStatus).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberName).HasMaxLength(450);

                entity.Property(e => e.MotherName).HasMaxLength(450);

                entity.Property(e => e.NationalId).HasMaxLength(450);

                entity.Property(e => e.PermanentAddress).HasMaxLength(450);

                entity.Property(e => e.Pono)
                    .HasMaxLength(450)
                    .HasColumnName("PONo");

                entity.Property(e => e.PresentAddress).HasMaxLength(450);

                entity.Property(e => e.Sex)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.InformationFezups)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_InformationFezup_BaseSchoolName");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.Brand).HasMaxLength(450);

                entity.Property(e => e.CompanyName).HasMaxLength(450);

                entity.Property(e => e.ContractNumber).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DamageDate).HasColumnType("datetime");

                entity.Property(e => e.DamageReason).HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.IdentityNo).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(450);

                entity.Property(e => e.Model).HasMaxLength(450);

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

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
                entity.ToTable("InventoryType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);
            });
            modelBuilder.Entity<FineForIssueReturn>(entity =>
            {
                entity.ToTable("FineForIssueReturn");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.FineForIssueReturns)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_FineForIssueReturn_FineForIssueReturn");
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.ToTable("JobStatus");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.JobStatusName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LibraryAuthority>(entity =>
            {
                entity.ToTable("LibraryAuthority");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<MainClass>(entity =>
            {
                entity.ToTable("MainClass");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<MemberCategory>(entity =>
            {
                entity.ToTable("MemberCategory");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberCategoryName).HasMaxLength(450);
            });

            modelBuilder.Entity<MemberInfo>(entity =>
            {
                entity.ToTable("MemberInfo");

                entity.Property(e => e.Answer).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(450);

                entity.Property(e => e.Director).HasMaxLength(450);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(400);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.FamilyContact).HasMaxLength(50);

                entity.Property(e => e.FatherName).HasMaxLength(450);

                entity.Property(e => e.ImageUrl).HasMaxLength(450);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.MemberName).HasMaxLength(450);

                entity.Property(e => e.MobileNoOffice).HasMaxLength(50);

                entity.Property(e => e.MobileNoPersonal).HasMaxLength(50);

                entity.Property(e => e.MotherName).HasMaxLength(450);

                entity.Property(e => e.Nid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.PermanentAddress).HasMaxLength(450);

                entity.Property(e => e.Pno)
                    .HasMaxLength(450)
                    .HasColumnName("PNO");

                entity.Property(e => e.PresentAddress).HasMaxLength(450);

                entity.Property(e => e.Region).HasMaxLength(450);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tntoffice)
                    .HasMaxLength(50)
                    .HasColumnName("TNTOffice");

                entity.Property(e => e.YearlyFee).HasMaxLength(450);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_MemberInfo_Area");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.BaseId)
                    .HasConstraintName("FK_MemberInfo_Base");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_MemberInfo_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_MemberInfo_BookInformation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MemberInfo_Designation");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.JobStatusId)
                    .HasConstraintName("FK_MemberInfo_JobStatus");

                entity.HasOne(d => d.MemberCategory)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.MemberCategoryId)
                    .HasConstraintName("FK_MemberInfo_MemberCategory");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_MemberInfo_Rank");

                entity.HasOne(d => d.SecurityQuestion)
                    .WithMany(p => p.MemberInfos)
                    .HasForeignKey(d => d.SecurityQuestionId)
                    .HasConstraintName("FK_MemberInfo_SecurityQuestion");
            });

            modelBuilder.Entity<MemberOfficialInfo>(entity =>
            {
                entity.HasKey(e => e.CodeNumber);

                entity.ToTable("MemberOfficialInfo");

                entity.Property(e => e.CodeNumber).HasMaxLength(256);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MemberOfficialIdentiy).ValueGeneratedOnAdd();

                entity.Property(e => e.OfficeMobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeTnt).HasColumnName("OfficeTNT");

                entity.Property(e => e.PerMobileNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberRegistration>(entity =>
            {
                entity.ToTable("MemberRegistration");

                entity.Property(e => e.Answer).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Department).HasMaxLength(450);

                entity.Property(e => e.Director).HasMaxLength(450);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(400);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.FamilyContact).HasMaxLength(50);

                entity.Property(e => e.FatherName).HasMaxLength(450);

                entity.Property(e => e.ImageUrl).HasMaxLength(450);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastPaymentDate).HasColumnType("datetime");

                entity.Property(e => e.MemberName).HasMaxLength(450);

                entity.Property(e => e.MobileNoOffice).HasMaxLength(50);

                entity.Property(e => e.MobileNoPersonal).HasMaxLength(50);

                entity.Property(e => e.MotherName).HasMaxLength(450);

                entity.Property(e => e.Nid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NID");

                entity.Property(e => e.PermanentAddress).HasMaxLength(450);

                entity.Property(e => e.Pno)
                    .HasMaxLength(450)
                    .HasColumnName("PNO");

                entity.Property(e => e.PresentAddress).HasMaxLength(450);

                entity.Property(e => e.Region).HasMaxLength(450);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tntoffice)
                    .HasMaxLength(50)
                    .HasColumnName("TNTOffice");

                entity.Property(e => e.YearlyFee).HasMaxLength(450);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_MemberRegistration_Area");

                entity.HasOne(d => d.Base)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.BaseId)
                    .HasConstraintName("FK_MemberRegistration_Base");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_MemberRegistration_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_MemberRegistration_BookInformation");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_MemberRegistration_Designation");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.JobStatusId)
                    .HasConstraintName("FK_MemberRegistration_JobStatus");

                entity.HasOne(d => d.MemberCategory)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.MemberCategoryId)
                    .HasConstraintName("FK_MemberRegistration_MemberCategory");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.RankId)
                    .HasConstraintName("FK_MemberRegistration_Rank");

                entity.HasOne(d => d.SecurityQuestion)
                    .WithMany(p => p.MemberRegistrations)
                    .HasForeignKey(d => d.SecurityQuestionId)
                    .HasConstraintName("FK_MemberRegistration_SecurityQuestion");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.Class).HasMaxLength(250);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.GroupTitle).HasMaxLength(250);

                entity.Property(e => e.Icon).HasMaxLength(250);

                entity.Property(e => e.IconName).HasMaxLength(250);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ModuleName).HasMaxLength(450);

                entity.Property(e => e.Title).HasMaxLength(450);
            });

            modelBuilder.Entity<NoticeInfo>(entity =>
            {
                entity.ToTable("NoticeInfo");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.NoticeEndDate).HasColumnType("datetime");

                entity.Property(e => e.NoticeTitle).HasMaxLength(450);

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.UploadPdffile)
                    .HasMaxLength(550)
                    .HasColumnName("UploadPDFFile");

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.NoticeInfos)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_NoticeInfo_BaseSchoolName");

                entity.HasOne(d => d.NoticeType)
                    .WithMany(p => p.NoticeInfos)
                    .HasForeignKey(d => d.NoticeTypeId)
                    .HasConstraintName("FK_NoticeInfo_NoticeType");
            });

            modelBuilder.Entity<NoticeType>(entity =>
            {
                entity.ToTable("NoticeType");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<OnlineBookRequest>(entity =>
            {
                entity.ToTable("OnlineBookRequest");

                entity.Property(e => e.AccessionNo).HasMaxLength(450);

                entity.Property(e => e.CancelDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

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

            modelBuilder.Entity<OnlineChat>(entity =>
            {
                entity.ToTable("OnlineChat");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(1500);

                entity.Property(e => e.ReceiverRole).HasMaxLength(450);

                entity.Property(e => e.SenderRole).HasMaxLength(450);
            });

            modelBuilder.Entity<PublishersInformation>(entity =>
            {
                entity.ToTable("PublishersInformation");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PublisherDate).HasMaxLength(450);

                entity.Property(e => e.PublisherPlace).HasMaxLength(450);

                entity.Property(e => e.PublishersAddress).HasMaxLength(450);

                entity.Property(e => e.PublishersName).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.PublishersInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_PublishersInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.PublishersInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_PublishersInformation_BookInformation");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("Rank");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RankName).HasMaxLength(450);

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Ranks)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK_Rank_Designation");
            });

            modelBuilder.Entity<ReaderInformation>(entity =>
            {
                entity.ToTable("ReaderInformation");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.InDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OutDate).HasColumnType("datetime");

                entity.Property(e => e.ReaderName).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.ReaderInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_ReaderInformation_BaseSchoolName");

                entity.HasOne(d => d.MemberInfo)
                    .WithMany(p => p.ReaderInformations)
                    .HasForeignKey(d => d.MemberInfoId)
                    .HasConstraintName("FK_ReaderInformation_MemberInfo");
            });

            modelBuilder.Entity<RegistrationQueueInfo>(entity =>
            {
                entity.ToTable("RegistrationQueueInfo");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Organization)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalNumber)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Pnumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PresentAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PresentDuty)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.RegistrationQueueInfoAreaNavigations)
                    .HasForeignKey(d => d.Area)
                    .HasConstraintName("FK_RegistrationQueueInfo_CommonCode1");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.RegistrationQueueInfoCategoryNavigations)
                    .HasForeignKey(d => d.Category)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegistrationQueueInfo_CommonCode");
            });

            modelBuilder.Entity<RegistrationQueueInfo1>(entity =>
            {
                entity.Property(e => e.Answer)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MemberName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nid)
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Pnumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reporting>(entity =>
            {
                entity.HasKey(e => e.SlNo);

                entity.ToTable("Reporting");

                entity.Property(e => e.SlNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Para1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Para2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Para3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Para4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QryType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Qryname).HasColumnType("text");

                entity.Property(e => e.ReportLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReportPath)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.XmlTableName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("xmlTableName");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RoleFeature>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.FeatureKey })
                    .HasName("PK_Company.RoleFeature");

                entity.ToTable("RoleFeature");
            });

            modelBuilder.Entity<RowInfo>(entity =>
            {
                entity.ToTable("RowInfo");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowName)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.ShelfInfo)
                    .WithMany(p => p.RowInfos)
                    .HasForeignKey(d => d.ShelfInfoId)
                    .HasConstraintName("FK_RowInfo_ShelfInfo");
            });

            modelBuilder.Entity<SecurityQuestion>(entity =>
            {
                entity.ToTable("SecurityQuestion");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(450);
            });

            modelBuilder.Entity<SelfControlInfo>(entity =>
            {
                entity.HasKey(e => e.SelfControlInfoIdentity)
                    .HasName("PK_ControlShipInfo");

                entity.ToTable("SelfControlInfo");

                entity.Property(e => e.ControlName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateDateId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CreateDateID");

                entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Level1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level2)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level3)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level4)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Level5)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentCode).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Remarks).HasMaxLength(150);

                entity.Property(e => e.SelfId).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ShelfInfo>(entity =>
            {
                entity.ToTable("ShelfInfo");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ShelfName)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<SoftCopyUpload>(entity =>
            {
                entity.ToTable("SoftCopyUpload");

                entity.Property(e => e.AuthorName).HasMaxLength(450);

                entity.Property(e => e.CorporateAuthor).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Editor).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StorePdffile)
                    .HasMaxLength(450)
                    .HasColumnName("StorePDFFile");

                entity.Property(e => e.TitleName).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SoftCopyUploads)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_SoftCopyUpload_BaseSchoolName");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.SoftCopyUploads)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_SoftCopyUpload_DocumentType");
            });

            modelBuilder.Entity<Source>(entity =>
            {
                entity.ToTable("Source");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<SourceInformation>(entity =>
            {
                entity.ToTable("SourceInformation");

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(450);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SourceName).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SourceInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_SourceInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.SourceInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_SourceInformation_BookInformation");
            });

            modelBuilder.Entity<SupplierInformation>(entity =>
            {
                entity.ToTable("SupplierInformation");

                entity.Property(e => e.Address).HasMaxLength(450);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(450);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks).HasMaxLength(450);

                entity.Property(e => e.SuppliedDate).HasColumnType("datetime");

                entity.Property(e => e.SupplierName).HasMaxLength(450);

                entity.HasOne(d => d.BaseSchoolName)
                    .WithMany(p => p.SupplierInformations)
                    .HasForeignKey(d => d.BaseSchoolNameId)
                    .HasConstraintName("FK_SupplierInformation_BaseSchoolName");

                entity.HasOne(d => d.BookInformation)
                    .WithMany(p => p.SupplierInformations)
                    .HasForeignKey(d => d.BookInformationId)
                    .HasConstraintName("FK_SupplierInformation_BookInformation");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.AccessionNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BanglaTitle).HasMaxLength(255);

                entity.Property(e => e.BookCategoryType).HasMaxLength(255);

                entity.Property(e => e.BookTitleId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Brno)
                    .HasMaxLength(255)
                    .HasColumnName("BRNo");

                entity.Property(e => e.Dep).HasMaxLength(255);

                entity.Property(e => e.PublicationDetails).HasMaxLength(255);

                entity.Property(e => e.RawNo).HasMaxLength(255);

                entity.Property(e => e.Remarks).HasMaxLength(255);

                entity.Property(e => e.SelfNo).HasMaxLength(255);

                entity.Property(e => e.Ser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Vol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Test2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test2");

                entity.Property(e => e.AccessionNumber).HasMaxLength(255);

                entity.Property(e => e.AuthorName).HasMaxLength(255);

                entity.Property(e => e.BookTitleId).HasMaxLength(255);

                entity.Property(e => e.CallNumber).HasMaxLength(255);

                entity.Property(e => e.Edition).HasMaxLength(255);

                entity.Property(e => e.Editor).HasMaxLength(255);

                entity.Property(e => e.Heading).HasMaxLength(255);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(255)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Pagenumber).HasMaxLength(255);

                entity.Property(e => e.PublicationPlace).HasMaxLength(255);

                entity.Property(e => e.PublisherName).HasMaxLength(255);

                entity.Property(e => e.Publishyear)
                    .HasMaxLength(255)
                    .HasColumnName("publishyear");

                entity.Property(e => e.SelfRow).HasMaxLength(255);

                entity.Property(e => e.Selfno).HasMaxLength(255);

                entity.Property(e => e.Titile).HasMaxLength(255);

                entity.Property(e => e.Vol).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.AttemptCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.BankCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword).HasMaxLength(50);

                entity.Property(e => e.Createdby).HasMaxLength(30);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.LasUpdateDate).HasColumnType("datetime");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredUserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MobileAlias).HasMaxLength(16);

                entity.Property(e => e.ParmitedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordValidity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.SecurityQustion).IsRequired();

                entity.Property(e => e.TransLimit).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.UserCategory)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.UserFullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.VerifyLimit).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<UserBankInfoMvc>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UserBankInfoMVC");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BrCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.LoweredRoleName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.NativeBranchCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubBranchCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SubBranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TransLimit).HasColumnType("decimal(12, 0)");

                entity.Property(e => e.UserFullName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.ZoneCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoneName)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogInfo>(entity =>
            {
                entity.HasKey(e => e.SlNo)
                    .HasName("PK_UnauthorizeEventLog");

                entity.ToTable("UserLogInfo");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTime).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginUserId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Macaddress)
                    .HasColumnType("text")
                    .HasColumnName("MACAddress");

                entity.Property(e => e.Remarks).HasColumnType("text");

                entity.Property(e => e.Workstation)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserUrlright>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.ApplicationId, e.UserId });

                entity.ToTable("UserURLRights");

                entity.Property(e => e.MenuId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstLevel)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MenuLevel)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MenuObjectDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuObjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Spname)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SPName");

                entity.Property(e => e.TableName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ThirdLevel)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UrlLink)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Visible).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<VAccountInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vAccountInfo");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AccountCode1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountCode_1");

                entity.Property(e => e.AccountCode2)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountCode_2");

                entity.Property(e => e.AccountCode4)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountCode_4");

                entity.Property(e => e.AccountCode5)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AccountCode_5");

                entity.Property(e => e.AccountHead)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.AccountHead1)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AccountHead_1");

                entity.Property(e => e.AccountHead2)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AccountHead_2");

                entity.Property(e => e.AccountHead3)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AccountHead_3");

                entity.Property(e => e.AccountHead4)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AccountHead_4");

                entity.Property(e => e.AccountHead5)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AccountHead_5");

                entity.Property(e => e.Accountcode3)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Accountcode_3");

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VideoFile>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DocumentLink).HasMaxLength(450);

                entity.Property(e => e.DocumentName).HasMaxLength(450);

                entity.Property(e => e.LastModifiedBy).HasMaxLength(450);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ZoneInfo>(entity =>
            {
                entity.HasKey(e => e.ZoneCode);

                entity.ToTable("ZoneInfo");

                entity.Property(e => e.ZoneCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.BankCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ZoneName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
