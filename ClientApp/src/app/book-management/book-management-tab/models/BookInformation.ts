export interface BookInformation {
    bookInformationId: number;
    bookCategoryId: number;
    bookCategory:string;
    baseSchoolNameId:number;
    languageId: number;
    language:string;
    mainClassId: number;
    mainClass:string;
    rowInfoId: number;
    rowName:string;
    shelfInfoId: number;
    shelfName:string;
    bookTitleInfoId: number;
    bookTitle:string;
    bookTitleEnglish:string;
    bookTitleBangla:string;
    coverImage: string;
    accessionNo: string;
    countOnlineRequest: number;
    volume: number;
    adminDamageStatus: number;
    borrowerDamageStatus: number;
    borrowerDamageFineAmount: number;
    borrowerDamageRemarks: string;
    borrowerDamageDate: Date;
    heading: string;
    callNumber: string;
    isbnNo: string;
    edition: string;
    issuable: number;
    pageNo: number;
    illustrations: number;
    notes: string;
    price: number;
    sourceId: number;
    source:string;
    accessionDate: Date;
    useableDays: string;
    mergeId:string;
    issueStatus:number;
    authorDamageStatus:number;
    reason:string;
    damageDate:Date;
    //menuPosition: string;
    isActive: boolean;
    bookBindingStatus:number
}