import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {FineForIssueReturn} from '../../models/FineForIssueReturn';
import {FineForIssueReturnService} from '../../service/FineForIssueReturn.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-fineforissuereturn-list',
  templateUrl: './fineforissuereturn-list.component.html',
  styleUrls: ['./fineforissuereturn-list.component.sass']
})
export class FineForIssueReturnListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: FineForIssueReturn[] = [];
  isLoading = false;
  baseSchoolNameId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','baseSchoolNameId','amount', 'dateCreated', 'actions'];
  dataSource: MatTableDataSource<FineForIssueReturn> = new MatTableDataSource();

  selection = new SelectionModel<FineForIssueReturn>(true, []);

  
  constructor(private snackBar: MatSnackBar,private route: ActivatedRoute,private FineForIssueReturnService:FineForIssueReturnService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getFineForIssueReturns();
  }
  
  getFineForIssueReturns() {
    this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.isLoading = true;
    this.FineForIssueReturnService.getFineForIssueReturns(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.baseSchoolNameId).subscribe(response => {
     

      this.dataSource.data = response.items; 
      console.log(this.dataSource.data);
      console.log("data");
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
  activeFineForIssueReturn(row){
    const id = row.fineForIssueReturnId; 
          this.confirmService.confirm('Confirm Active message', 'Are You Sure Active This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.FineForIssueReturnService.activeFineForIssueReturn(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.reloadCurrentRoute();
            this.snackBar.open('Information Active Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}
inActiveFineForIssueReturn(row){
  const id = row.fineForIssueReturnId; 
        this.confirmService.confirm('Confirm  InActive message', 'Are You Sure InActive This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.FineForIssueReturnService.inActiveFineForIssueReturn(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information InActive Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  
}
reloadCurrentRoute() {
  let currentUrl = this.router.url;
  this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
      this.router.navigate([currentUrl]);
  });
}
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getFineForIssueReturns();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getFineForIssueReturns();
  } 
  deleteItem(row) {
    const id = row.fineForIssueReturnId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      console.log(result);
      if (result) { 
        this.FineForIssueReturnService.delete(id).subscribe(() => {
          this.getFineForIssueReturns();
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
