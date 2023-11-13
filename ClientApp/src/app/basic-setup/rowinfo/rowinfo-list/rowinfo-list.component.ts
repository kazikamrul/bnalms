import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {RowInfo} from '../../models/RowInfo';
import {RowInfoService} from '../../service/RowInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-rowinfo-list',
  templateUrl: './rowinfo-list.component.html',
  styleUrls: ['./rowinfo-list.component.sass']
})
export class RowInfoListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: RowInfo[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','shelfName','rowName', 'actions'];
  dataSource: MatTableDataSource<RowInfo> = new MatTableDataSource();

  selection = new SelectionModel<RowInfo>(true, []);

  
  constructor(private snackBar: MatSnackBar,private RowInfoService:RowInfoService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getRowInfos();
  }
  
  getRowInfos() {
    this.isLoading = true;
    this.RowInfoService.getRowInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getRowInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getRowInfos();
  } 
  deleteItem(row) {
    const id = row.rowInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.RowInfoService.delete(id).subscribe(() => {
          this.getRowInfos();
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
