import { DamageInformationByLibrary } from "./DamageInformationByLibrary";

export interface IDamageInformationByLibraryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DamageInformationByLibrary[];
}
export class DamageInformationByLibraryPagination implements IDamageInformationByLibraryPagination {
    totalPages:number;
    itemsFrom:number;
    itemsTo:number;
    totalItemsCount:number;
    items: DamageInformationByLibrary[] = [];


}
