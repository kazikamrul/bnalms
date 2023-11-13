import { InformationFezup } from "./InformationFezup";

export interface IInformationFezupPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: InformationFezup[];
}
export class InformationFezupPagination implements IInformationFezupPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: InformationFezup[] = [];


}
