import { MainClass } from "./MainClass";

export interface IMainClassPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MainClass[];
}
export class MainClassPagination implements IMainClassPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MainClass[] = [];


}
