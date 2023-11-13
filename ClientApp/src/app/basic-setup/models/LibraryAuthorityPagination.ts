import { LibraryAuthority } from "./LibraryAuthority";

export interface ILibraryAuthorityPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LibraryAuthority[];
}
export class LibraryAuthorityPagination implements ILibraryAuthorityPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: LibraryAuthority[] = [];


}
