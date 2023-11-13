import { ReaderInformation } from "./ReaderInformation";

export interface IReaderInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ReaderInformation[];
}
export class ReaderInformationPagination implements IReaderInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ReaderInformation[] = [];


}
