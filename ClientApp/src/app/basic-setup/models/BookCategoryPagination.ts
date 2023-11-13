import { BookCategory } from "./BookCategory";

export interface IBookCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookCategory[];
}
export class BookCategoryPagination implements IBookCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: BookCategory[] = [];


}
