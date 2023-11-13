import { MemberCategory } from "./MemberCategory";

export interface IMemberCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberCategory[];
}
export class MemberCategoryPagination implements IMemberCategoryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberCategory[] = [];


}
