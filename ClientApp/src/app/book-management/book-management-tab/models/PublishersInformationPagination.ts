import { PublishersInformation } from "./PublishersInformation";

export interface IPublishersInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PublishersInformation[];
}
export class PublishersInformationPagination implements IPublishersInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: PublishersInformation[] = [];


}
