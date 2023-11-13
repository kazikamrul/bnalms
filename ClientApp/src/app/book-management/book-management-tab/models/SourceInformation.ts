export interface SourceInformation {
    sourceInformationId: number;
    baseSchoolNameId: number;
    bookInformationId: number;
    sourceName: string;
    address: string;
    phone:number;
    email: string;
    orderDate: Date;
    receivedDate: Date;
    remarks: string;
    //menuPosition: string;
    isActive: boolean;
}