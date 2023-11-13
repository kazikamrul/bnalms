using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BaseSchoolName : BaseDomainEntity
    {
        public BaseSchoolName()
        {
            BookTitleInfos = new HashSet<BookTitleInfo>();
            BookInformations = new HashSet<BookInformation>();
            BookIssueAndSubmissions = new HashSet<BookIssueAndSubmission>();
            AuthorInformations = new HashSet<AuthorInformation>();
            PublishersInformations = new HashSet<PublishersInformation>();
            SupplierInformations = new HashSet<SupplierInformation>();
            SourceInformations = new HashSet<SourceInformation>();
            MemberInfos = new HashSet<MemberInfo>();
            FeeInformations = new HashSet<FeeInformation>();
            ReaderInformations = new HashSet<ReaderInformation>();
            BookBindingInfos = new HashSet<BookBindingInfo>();
            DamageInformationByLibraries = new HashSet<DamageInformationByLibrary>();
            FileInformations = new HashSet<FileInformation>();
            SoftCopyUploads = new HashSet<SoftCopyUpload>();
            NoticeInfos = new HashSet<NoticeInfo>();
            EventInfos = new HashSet<EventInfo>();
            Bulletins = new HashSet<Bulletin>();
            InformationFezups = new HashSet<InformationFezup>();
            MemberRegistrations = new HashSet<MemberRegistration>();
            OnlineBookRequests = new HashSet<OnlineBookRequest>();
            HelpLines = new HashSet<HelpLine>();
            OnlineChats = new HashSet<OnlineChat>();
            Inventories = new HashSet<Inventory>();
            FineForIssueReturns = new HashSet<FineForIssueReturn>();
        }

        public int BaseSchoolNameId { get; set; }
        public int? BaseNameId { get; set; }
        public string? SchoolName { get; set; }
        public string? ShortName { get; set; }
        public string? SchoolLogo { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? ContactPerson { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Cellphone { get; set; }
        public string? Email { get; set; }
        public string? Fax { get; set; }
        public int? BranchLevel { get; set; }
        public int? FirstLevel { get; set; }
        public int? SecondLevel { get; set; }
        public int? ThirdLevel { get; set; }
        public int? FourthLevel { get; set; }
        public int? FifthLevel { get; set; }
        public string? ServerName { get; set; }

        public virtual BaseName? BaseName { get; set; }
        public virtual ICollection<DamageInformationByLibrary> DamageInformationByLibraries { get; set; }
        public virtual ICollection<FileInformation> FileInformations { get; set; }
        public virtual ICollection<SoftCopyUpload> SoftCopyUploads { get; set; }
        public virtual ICollection<BookBindingInfo> BookBindingInfos { get; set; }
        public virtual ICollection<BookTitleInfo> BookTitleInfos { get; set; }
        public virtual ICollection<Bulletin> Bulletins { get; set; }
        public virtual ICollection<HelpLine> HelpLines { get; set; }
        public virtual ICollection<InformationFezup> InformationFezups { get; set; }
        public virtual ICollection<BookIssueAndSubmission> BookIssueAndSubmissions { get; set; }
        public virtual ICollection<NoticeInfo> NoticeInfos { get; set; }
        public virtual ICollection<BookInformation> BookInformations { get; set; }
        public virtual ICollection<AuthorInformation> AuthorInformations { get; set; }
        public virtual ICollection<PublishersInformation> PublishersInformations { get; set; }
        public virtual ICollection<SupplierInformation> SupplierInformations { get; set; }
        public virtual ICollection<SourceInformation> SourceInformations { get; set; }
        public virtual ICollection<MemberInfo> MemberInfos { get; set; }
        public virtual ICollection<OnlineChat> OnlineChats { get; set; }
        public virtual ICollection<MemberRegistration> MemberRegistrations { get; set; }
        public virtual ICollection<FeeInformation> FeeInformations { get; set; }
        public virtual ICollection<ReaderInformation> ReaderInformations { get; set; }
        public virtual ICollection<EventInfo> EventInfos { get; set; }
        public virtual ICollection<OnlineBookRequest> OnlineBookRequests { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<FineForIssueReturn> FineForIssueReturns { get; set; }
    }
}
