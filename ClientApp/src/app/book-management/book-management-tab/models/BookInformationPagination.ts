import { BookInformation } from "./BookInformation";

export interface IBookInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookInformation[];
}
export class BookInformationPagination implements IBookInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookInformation[] = [];


}
