import { Designation } from "./Designation";

export interface IDesignationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Designation[];
}
export class DesignationPagination implements IDesignationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: Designation[] = [];


}
