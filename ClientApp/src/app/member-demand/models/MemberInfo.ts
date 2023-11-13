import { NgbTime } from "@ng-bootstrap/ng-bootstrap/timepicker/ngb-time";

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
    areaId:number;
    baseId:NgbTime;
    securityQuestionId:number;
    answer:string;
    jobStatus:string;
    memberInfoIdentity: number;
    email: string;
    imageUrl: string;
    region:string;
    director:string;
    memberName: string;
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
    tntOffice: string;
    mobileNoOffice: string;
    familyContact: string;
    mobileNoPersonal: string;
    //menuPosition: string;
    isActive: boolean;
}

