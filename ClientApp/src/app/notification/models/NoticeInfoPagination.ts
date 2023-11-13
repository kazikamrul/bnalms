import { NoticeInfo } from "./NoticeInfo";

export interface INoticeInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NoticeInfo[];
}
export class NoticeInfoPagination implements INoticeInfoPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: NoticeInfo[] = [];


}
