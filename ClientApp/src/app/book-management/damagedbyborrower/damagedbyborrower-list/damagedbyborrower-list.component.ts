import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookIssueAndSubmission} from '../../models/BookIssueAndSubmission';
import {BookIssueAndSubmissionService} from '../../service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-damagedbyborrower-list',
  templateUrl: './damagedbyborrower-list.component.html',
  styleUrls: ['./damagedbyborrower-list.component.sass']
})
export class DamagedByBorrowerListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookIssueAndSubmission[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','accessionNo','pno','bookTitle', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getDamagedByBorrowers();
  }
  
  getDamagedByBorrowers() {
    this.isLoading = true;
    this.BookIssueAndSubmissionService.getBookIssueAndSubmissions(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getDamagedByBorrowers();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getDamagedByBorrowers();
  } 
  deleteItem(row) {
    const id = row.bookIssueAndSubmissionId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.delete(id).subscribe(() => {
          this.getDamagedByBorrowers();
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
