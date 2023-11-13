export interface BookIssueAndSubmission {
    bookIssueAndSubmissionId:number;
    baseSchoolNameId: number;
    memberInfoId: number;
    bookInformationId: number;
    shelfInfoId: number;
    rowInfoId: number;
    issueDate: Date;
    dueDate: Date;
    submissionDate:Date;
    fineForLate: number;
    fineForDamage:number;
    isDamage: string;
    pno: string;
    bookStatus: boolean;
    cancelDate: Date;
    cancelId: string;
    onlineRequested: number;
    acceptDate: Date;
    requestDate:Date;
    remarksForIssue: string;
    mailTracking: number;
    seen: boolean;
    remarksForSubmission: string;
    issuedBy: Date;
    menuPosition:number;
    isActive: boolean;
    bookTitleBangla:string;
}