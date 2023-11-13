export interface SupplierInformation {
    supplierInformationId: number;
    baseSchoolNameId: number;
    bookInformationId: number;
    supplierName: string;
    address: string;
    phone:string;
    email: string;
    suppliedDate: Date;
    receivedDate: Date;
    remarks: string;
    //menuPosition: string;
    isActive: boolean;
}