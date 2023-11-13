import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {MainClass} from '../../models/MainClass';
import {MainClassService} from '../../service/MainClass.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-mainclass-list',
  templateUrl: './mainclass-list.component.html',
  styleUrls: ['./mainclass-list.component.sass']
})
export class MainClassListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: MainClass[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','name', 'actions'];
  dataSource: MatTableDataSource<MainClass> = new MatTableDataSource();

  selection = new SelectionModel<MainClass>(true, []);

  
  constructor(private snackBar: MatSnackBar,private MainClassService:MainClassService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMainClasses();
  }
  
  getMainClasses() {
    this.isLoading = true;
    this.MainClassService.getMainClasses(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getMainClasses();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMainClasses();
  } 
  deleteItem(row) {
    const id = row.mainClassId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.MainClassService.delete(id).subscribe(() => {
          this.getMainClasses();
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
