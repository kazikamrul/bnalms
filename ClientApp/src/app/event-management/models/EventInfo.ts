export interface EventInfo {
    eventInfoId: number;
    baseSchoolNameId: number;
    eventName:string;
    eventSubject:string;
    eventPurpose: string;
    eventLocation: string;
    eventGuest: number;
    eventCharge: string;
    eventFrom: Date;
    eventTo: Date;
    partcipant: number;
    eventBudget: number;
    approveBadget: number;
    approvedName: string;
    budgetDate: Date;
    remarks: string;
    isActive: boolean;
}