import { SupplierInformation } from "./SupplierInformation";

export interface ISupplierInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SupplierInformation[];
}
export class SupplierInformationPagination implements ISupplierInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SupplierInformation[] = [];


}
