import { DemandBook } from "./DemandBook";

export interface IDemandBookPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DemandBook[];
}
export class DemandBookPagination implements IDemandBookPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DemandBook[] = [];


}
