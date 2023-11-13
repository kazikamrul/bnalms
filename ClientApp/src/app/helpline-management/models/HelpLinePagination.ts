import { HelpLine } from "./HelpLine";

export interface IHelpLinePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: HelpLine[];
}
export class HelpLinePagination implements IHelpLinePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: HelpLine[] = [];


}
