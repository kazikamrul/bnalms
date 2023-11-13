import { BookTitleInfo } from "./BookTitleInfo";

export interface IBookTitleInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookTitleInfo[];
}
export class BookTitleInfoPagination implements IBookTitleInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookTitleInfo[] = [];


}
