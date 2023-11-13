import { RowInfo } from "./RowInfo";

export interface IRowInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RowInfo[];
}
export class RowInfoPagination implements IRowInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: RowInfo[] = [];


}
