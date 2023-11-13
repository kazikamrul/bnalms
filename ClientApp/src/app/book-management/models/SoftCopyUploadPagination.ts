import { SoftCopyUpload } from "./SoftCopyUpload";

export interface ISoftCopyUploadPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SoftCopyUpload[];
}
export class SoftCopyUploadPagination implements ISoftCopyUploadPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: SoftCopyUpload[] = [];


}
