export interface MemberInfo {
    memberInfoId: number;
    baseSchoolNameId: number;
    bookInformationId: number;
    memberCategoryId: number;
    memberCategory:string;
    rankId: number;
    rank:string;
    designationId: number;
    designation:string;
    jobStatusId: number;
    jobStatus:string;
    memberInfoIdentity: number;
    email: string;
    imageUrl: string;
    region:string;
    director:string;
    memberName: string;
    memberShipDate:Date;
    memberExpireDate:Date;
    memberShipNumber:number;
    fatherName: string;
    motherName: string;
    yearlyFee: string;
    presentAddress: string;
    permanentAddress: string;
    nid: string;
    sex: string;
    issueDate: Date;
    expireDate: Date;
    dob: Date;
    pno: string;
    department: string;
    baseSchoolName:string;
    tntOffice: string;
    mobileNoOffice: string;
    familyContact: string;
    mobileNoPersonal: string;
    //menuPosition: string; 
    isActive: boolean;
    issueQty:number,
    lastPaymentDate:Date,
}

