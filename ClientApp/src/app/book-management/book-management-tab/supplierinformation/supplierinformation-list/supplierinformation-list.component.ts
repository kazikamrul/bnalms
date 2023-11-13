import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {SupplierInformation} from '../../models/SupplierInformation';
import {SupplierInformationService} from '../../service/SupplierInformation.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BookInformationService } from '../../service/BookInformation.service';


@Component({
  selector: 'app-supplierinformation-list',
  templateUrl: './supplierinformation-list.component.html',
  styleUrls: ['./supplierinformation-list.component.sass']
})
export class SupplierInformationListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: SupplierInformation[] = [];
  isLoading = false;
  bookInformationId:string;
  bookTitle:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','supplierName','phone','receivedDate', 'actions'];
  dataSource: MatTableDataSource<SupplierInformation> = new MatTableDataSource();

  selection = new SelectionModel<SupplierInformation>(true, []);

  
  constructor(private route: ActivatedRoute,private bookInformationService: BookInformationService,private snackBar: MatSnackBar,private SupplierInformationService:SupplierInformationService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    const bookInformationId  = this.route.snapshot.paramMap.get('bookInformationId');
    this.bookInformationService.find(Number(bookInformationId)).subscribe(res=>{      
      this.bookTitle =  res.bookTitle;
    });

    this.getSupplierInformations();
  }
  
  getSupplierInformations() {
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    this.isLoading = true;
    this.SupplierInformationService.getSupplierInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.bookInformationId).subscribe(response => {
     

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
    this.getSupplierInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSupplierInformations();
  } 
  deleteItem(row) {
    const id = row.supplierInformationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.SupplierInformationService.delete(id).subscribe(() => {
          this.getSupplierInformations();
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
