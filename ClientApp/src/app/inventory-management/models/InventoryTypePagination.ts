import { InventoryType } from "./InventoryType";

export interface IInventoryTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: InventoryType[];
}
export class InventoryTypePagination implements IInventoryTypePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: InventoryType[] = [];


}
