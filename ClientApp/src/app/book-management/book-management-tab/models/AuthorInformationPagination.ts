import { AuthorInformation } from "./AuthorInformation";

export interface IAuthorInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AuthorInformation[];
}
export class AuthorInformationPagination implements IAuthorInformationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AuthorInformation[] = [];


}
