import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {EventInfo} from '../../models/EventInfo';
import {EventInfoService} from '../../service/EventInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-eventinfo-list',
  templateUrl: './eventinfo-list.component.html',
  styleUrls: ['./eventinfo-list.component.sass']
})
export class EventInfoListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: EventInfo[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','eventName','eventSubject','eventPurpose','eventLocation','eventFrom','eventTo','eventGuest', 'actions'];
  dataSource: MatTableDataSource<EventInfo> = new MatTableDataSource();

  selection = new SelectionModel<EventInfo>(true, []);

  
  constructor(private snackBar: MatSnackBar,private EventInfoService:EventInfoService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getEventInfos();
  }
  
  getEventInfos() {
    this.isLoading = true;
    this.EventInfoService.getEventInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getEventInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getEventInfos();
  } 
  deleteItem(row) {
    const id = row.eventInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.EventInfoService.delete(id).subscribe(() => {
          this.getEventInfos();
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
