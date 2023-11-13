import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {InformationFezup} from '../../models/InformationFezup';
import {InformationFezupService} from '../../service/InformationFezup.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-informationfezup-list',
  templateUrl: './informationfezup-list.component.html',
  styleUrls: ['./informationfezup-list.component.sass']
})
export class InformationFezupListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: InformationFezup[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','poNo', 'memberName','nationalId','actions'];
  dataSource: MatTableDataSource<InformationFezup> = new MatTableDataSource();

  selection = new SelectionModel<InformationFezup>(true, []);

  
  constructor(private snackBar: MatSnackBar,private InformationFezupService:InformationFezupService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getInformationFezups();
  }
  
  getInformationFezups() {
    this.isLoading = true;
    this.InformationFezupService.getInformationFezups(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getInformationFezups();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getInformationFezups();
  } 
  deleteItem(row) {
    const id = row.informationFezupId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.InformationFezupService.delete(id).subscribe(() => {
          this.getInformationFezups();
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
