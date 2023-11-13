import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {PublishersInformation} from '../../models/PublishersInformation';
import {PublishersInformationService} from '../../service/PublishersInformation.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookInformationService } from '../../service/BookInformation.service';


@Component({
  selector: 'app-publishersinformation-list',
  templateUrl: './publishersinformation-list.component.html',
  styleUrls: ['./publishersinformation-list.component.sass']
})
export class PublishersInformationListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: PublishersInformation[] = [];
  isLoading = false;
  bookInformationId:string;
  bookTitle:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','publishersName','publishersAddress','publisherDate', 'actions'];
  dataSource: MatTableDataSource<PublishersInformation> = new MatTableDataSource();

  selection = new SelectionModel<PublishersInformation>(true, []);

  
  constructor(private route: ActivatedRoute,private bookInformationService: BookInformationService,private snackBar: MatSnackBar,private PublishersInformationService:PublishersInformationService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    const bookInformationId  = this.route.snapshot.paramMap.get('bookInformationId');
    this.bookInformationService.find(Number(bookInformationId)).subscribe(res=>{      
      this.bookTitle =  res.bookTitle;
    });


    this.getPublishersInformations();
  }
  
  getPublishersInformations() {
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    this.isLoading = true;
    this.PublishersInformationService.getPublishersInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.bookInformationId).subscribe(response => {
     

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
    this.getPublishersInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getPublishersInformations();
  } 
  deleteItem(row) {
    const id = row.publishersInformationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.PublishersInformationService.delete(id).subscribe(() => {
          this.getPublishersInformations();
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
