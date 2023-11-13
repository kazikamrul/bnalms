import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {AuthorInformation} from '../../models/AuthorInformation';
import {AuthorInformationService} from '../../service/AuthorInformation.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookInformationService } from '../../service/BookInformation.service';


@Component({
  selector: 'app-authornformation-list',
  templateUrl: './authornformation-list.component.html',
  styleUrls: ['./authornformation-list.component.sass']
})
export class AuthorInformationListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: AuthorInformation[] = [];
  isLoading = false;
  bookInformationId:any;
  bookTitle:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','authorityCategory','authorName', 'actions'];
  dataSource: MatTableDataSource<AuthorInformation> = new MatTableDataSource();

  selection = new SelectionModel<AuthorInformation>(true, []);

  
  constructor(private route: ActivatedRoute,private bookInformationService: BookInformationService,private snackBar: MatSnackBar,private AuthorInformationService:AuthorInformationService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    const bookInformationId  = this.route.snapshot.paramMap.get('bookInformationId');
    this.bookInformationService.find(Number(bookInformationId)).subscribe(res=>{      
      this.bookTitle =  res.bookTitle;
    });
    
    this.getAuthorInformations();

  }
  
  getAuthorInformations() {
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    this.isLoading = true;
    this.AuthorInformationService.getAuthorInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.bookInformationId).subscribe(response => {
     

      this.dataSource.data = response.items; 
      console.log(this.bookTitle);
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
    this.getAuthorInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAuthorInformations();
  } 
  deleteItem(row) {
    const id = row.authorInformationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.AuthorInformationService.delete(id).subscribe(() => {
          this.getAuthorInformations();
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
