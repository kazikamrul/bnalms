import { Inventory } from "./Inventory";

export interface IInventoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Inventory[];
}
export class InventoryPagination implements IInventoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Inventory[] = [];


}
