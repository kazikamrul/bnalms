import {FineForIssueReturn} from "./FineForIssueReturn";

export interface IFineForIssueReturnPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FineForIssueReturn[];
}
export class FineForIssueReturnPagination implements IFineForIssueReturnPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FineForIssueReturn[] = [];


}
