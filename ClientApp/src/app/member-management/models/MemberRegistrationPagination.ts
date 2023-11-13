import { MemberRegistration } from "./MemberRegistration";

export interface IMemberRegistrationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberRegistration[];
}
export class MemberRegistrationPagination implements IMemberRegistrationPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: MemberRegistration[] = [];


}
