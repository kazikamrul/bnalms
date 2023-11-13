import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {DamageInformationByLibrary} from '../../models/DamageInformationByLibrary';
import {DamageInformationByLibraryService} from '../../service/DamageInformationByLibrary.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-damageinformationbylibrary-list',
  templateUrl: './damageinformationbylibrary-list.component.html',
  styleUrls: ['./damageinformationbylibrary-list.component.sass']
})
export class DamageInformationByLibraryListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: DamageInformationByLibrary[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','bookTitle','accessionNo','damageBy','remarks', 'actions'];
  dataSource: MatTableDataSource<DamageInformationByLibrary> = new MatTableDataSource();

  selection = new SelectionModel<DamageInformationByLibrary>(true, []);

  
  constructor(private snackBar: MatSnackBar,private DamageInformationByLibraryService:DamageInformationByLibraryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getDamageInformationByLibrarys();
  }
  
  getDamageInformationByLibrarys() {
    this.isLoading = true;
    this.DamageInformationByLibraryService.getDamageInformationByLibrarys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getDamageInformationByLibrarys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getDamageInformationByLibrarys();
  } 
  deleteItem(row) {
    const id = row.damageInformationByLibraryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.DamageInformationByLibraryService.delete(id).subscribe(() => {
          this.getDamageInformationByLibrarys();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });

        })
      }
      
    })
    
  }
}
