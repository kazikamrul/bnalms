import { VideoFile } from "./VideoFile";

export interface IVideoFilePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: VideoFile[];
}
export class VideoFilePagination implements IVideoFilePagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: VideoFile[] = [];


}
