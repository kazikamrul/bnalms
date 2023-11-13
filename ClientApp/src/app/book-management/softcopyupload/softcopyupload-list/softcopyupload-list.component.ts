import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {SoftCopyUpload} from '../../models/SoftCopyUpload';
import {SoftCopyUploadService} from '../../service/SoftCopyUpload.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import {Role} from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';


@Component({
  selector: 'app-softcopyupload-list',
  templateUrl: './softcopyupload-list.component.html',
  styleUrls: ['./softcopyupload-list.component.sass']
})
export class SoftCopyUploadListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  ELEMENT_DATA: SoftCopyUpload[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  role:any;
  traineeId:any;
  branchId:any;

  displayedColumns: string[] = [ 'sl','titleName','authorName','corporateAuthor','editor','storePDFFile', 'actions'];
  dataSource: MatTableDataSource<SoftCopyUpload> = new MatTableDataSource();

  selection = new SelectionModel<SoftCopyUpload>(true, []);

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private SoftCopyUploadService:SoftCopyUploadService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)
    if(this.role == this.userRole.SuperAdmin){
      this.branchId = 1;
    }
   console.log("dept id");
   console.log(this.branchId);
    this.getSoftCopyUploads();
  }
  
  getSoftCopyUploads() {
    this.isLoading = true;
    this.SoftCopyUploadService.getSoftCopyUploads(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.branchId).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log(this.dataSource.data);
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
    this.getSoftCopyUploads();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSoftCopyUploads();
  } 
  deleteItem(row) {
    const id = row.softCopyUploadId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.SoftCopyUploadService.delete(id).subscribe(() => {
          this.getSoftCopyUploads();
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
