import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
// import {MemberInfo} from '../../models/MemberInfo';
// import {MemberInfoService} from '../../service/MemberInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MemberInfo } from '../models/MemberInfo';
import { MemberInfoService} from '../service/MemberInfo.service';
import {FeeInformationService} from '../service/FeeInformation.service';
@Component({
  selector: 'app-fineforissuereturn-list',
  templateUrl: './fineforissuereturn-list.component.html',
  styleUrls: ['./fineforissuereturn-list.component.sass']
})
export class FineForIssuereturnListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: MemberInfo[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  fineForIssueReturnList:any;
  displayedColumns: string[] = [ 'sl','imageUrl','memberName','area','director','mobileNoPersonal','email','expireDate', 'actions'];
  dataSource: MatTableDataSource<MemberInfo> = new MatTableDataSource();

  selection = new SelectionModel<MemberInfo>(true, []);

  
  constructor(private snackBar: MatSnackBar,private FeeInformationService:FeeInformationService,private MemberInfoService:MemberInfoService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    //this.getMemberInfos();
    this.getFineForIssueReturnList();
  }
  
  getFineForIssueReturnList(){
    this.FeeInformationService.getFineForIssueReturnList(201,this.searchText).subscribe(response => {
      this.fineForIssueReturnList = response; 
    })
  }
  // getMemberInfos() {
  //   this.isLoading = true;
  //   this.MemberInfoService.getMemberInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

  //     this.dataSource.data = response.items; 
  //     this.paging.length = response.totalItemsCount    
  //     this.isLoading = false;
  //   })
  // }
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
  acctiveMember(row){
    const id = row.memberInfoId; 
          this.confirmService.confirm('Confirm Active message', 'Are You Sure Active This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.MemberInfoService.acctiveMember(id).subscribe(() => {
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
inAcctiveMember(row){
  const id = row.memberInfoId; 
        this.confirmService.confirm('Confirm  InActive message', 'Are You Sure InActive This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.MemberInfoService.inAcctiveMember(id).subscribe(() => {
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
   // this.getMemberInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getFineForIssueReturnList();
    //this.getMemberInfos();
  } 
  deleteItem(row) {
    const id = row.memberInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.MemberInfoService.delete(id).subscribe(() => {
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
