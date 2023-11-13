import { FeeInformation } from "./FeeInformation";

export interface IFeeInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FeeInformation[];
}
export class FeeInformationPagination implements IFeeInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: FeeInformation[] = [];


}
