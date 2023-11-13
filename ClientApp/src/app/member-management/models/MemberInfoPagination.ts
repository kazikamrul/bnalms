import { MemberInfo } from "./MemberInfo";

export interface IMemberInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberInfo[];
}
export class MemberInfoPagination implements IMemberInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberInfo[] = [];


}
