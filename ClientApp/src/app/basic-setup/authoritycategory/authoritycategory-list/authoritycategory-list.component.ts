import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {AuthorityCategory} from '../../models/AuthorityCategory';
import {AuthorityCategoryService} from '../../service/AuthorityCategory.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-authoritycategory-list',
  templateUrl: './authoritycategory-list.component.html',
  styleUrls: ['./authoritycategory-list.component.sass']
})
export class AuthorityCategoryListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: AuthorityCategory[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','authorCategoryName', 'actions'];
  dataSource: MatTableDataSource<AuthorityCategory> = new MatTableDataSource();

  selection = new SelectionModel<AuthorityCategory>(true, []);

  
  constructor(private snackBar: MatSnackBar,private AuthorityCategoryService:AuthorityCategoryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getAuthorityCategorys();
  }
  
  getAuthorityCategorys() {
    this.isLoading = true;
    this.AuthorityCategoryService.getAuthorityCategorys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getAuthorityCategorys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAuthorityCategorys();
  } 
  deleteItem(row) {
    const id = row.authorityCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.AuthorityCategoryService.delete(id).subscribe(() => {
          this.getAuthorityCategorys();
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
