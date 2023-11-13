export interface FeeInformation {
    feeInformationId: number;
    baseSchoolNameId: number;
    memberInfoId:number;
    bookInformationId:number;
    pno:string;
    feeCategoryId: number;
    paidDate: Date;
    expiredDate:string;
    paidAmount: number;
    receivedAmount: string;
    isActive: boolean;
}