import { AuthorityCategory } from "./AuthorityCategory";

export interface IAuthorityCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AuthorityCategory[];
}
export class AuthorityCategoryPagination implements IAuthorityCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: AuthorityCategory[] = [];


}
