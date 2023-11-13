import { EventInfo } from "./EventInfo";

export interface IEventInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EventInfo[];
}
export class EventInfoPagination implements IEventInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: EventInfo[] = [];


}
