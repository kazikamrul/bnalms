import { SourceInformation } from "./SourceInformation";

export interface ISourceInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SourceInformation[];
}
export class SourceInformationPagination implements ISourceInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SourceInformation[] = [];


}
