import { BookBindingInfo } from "./BookBindingInfo";

export interface IBookBindingInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookBindingInfo[];
}
export class BookBindingInfoPagination implements IBookBindingInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookBindingInfo[] = [];


}
