import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {MemberCategory} from '../../models/MemberCategory';
import {MemberCategoryService} from '../../service/MemberCategory.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-membercategory-list',
  templateUrl: './membercategory-list.component.html',
  styleUrls: ['./membercategory-list.component.sass']
})
export class MemberCategoryListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: MemberCategory[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','memberCategoryName', 'actions'];
  dataSource: MatTableDataSource<MemberCategory> = new MatTableDataSource();

  selection = new SelectionModel<MemberCategory>(true, []);

  
  constructor(private snackBar: MatSnackBar,private MemberCategoryService:MemberCategoryService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getMemberCategorys();
  }
  
  getMemberCategorys() {
    this.isLoading = true;
    this.MemberCategoryService.getMemberCategorys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getMemberCategorys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMemberCategorys();
  } 
  deleteItem(row) {
    const id = row.memberCategoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.MemberCategoryService.delete(id).subscribe(() => {
          this.getMemberCategorys();
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
