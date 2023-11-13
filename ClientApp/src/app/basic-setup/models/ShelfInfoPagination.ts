import { ShelfInfo } from "./ShelfInfo";

export interface IShelfInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ShelfInfo[];
}
export class ShelfInfoPagination implements IShelfInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: ShelfInfo[] = [];


}
