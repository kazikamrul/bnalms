import { BookIssueAndSubmission } from "./BookIssueAndSubmission";

export interface IBookIssueAndSubmissionPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookIssueAndSubmission[];
}
export class BookIssueAndSubmissionPagination implements IBookIssueAndSubmissionPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookIssueAndSubmission[] = [];


}
