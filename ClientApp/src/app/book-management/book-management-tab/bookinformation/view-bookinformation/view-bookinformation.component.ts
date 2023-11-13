import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookInformation } from '../../models/BookInformation';
import { BookInformationService } from '../../service/BookInformation.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import {Location} from '@angular/common';

@Component({
  selector: 'app-view-bookinformation',
  templateUrl: './view-bookinformation.component.html',
  styleUrls: ['./view-bookinformation.component.sass']
})
export class ViewBookInformationComponent implements OnInit {

  masterData = MasterData;
  showHideDiv:any;
  ELEMENT_DATA: BookInformation[] = [];
  isLoading = false;
  bookInformationId: number; 
    bookCategoryId: number;
    bookCategory:string;
    languageId: number;
    language:string;
    mainClassId: number;
    mainClass:string;
    rowInfoId: number;
    rowName:string;
    shelfInfoId: number;
    shelfName:string;
    bookTitleInfoId: number;
    bookTitle:string;
    coverImage: string;
    accessionNo: string;
    volume: number;
    heading: string;
    callNumber: string;
    isbnNo: string;
    edition: string;
    issuable: number;
    pageNo: number;
    illustrations: number;
    notes: string;
    price: number;
    sourceId: number;
    source:string;
    accessionDate: Date;
    useableDays: string;
    role:any;
    branchId:any;
    userRole = Role;

  constructor(private route: ActivatedRoute,private _location: Location,private authService: AuthService,private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    const id = this.route.snapshot.paramMap.get('bookInformationId'); 
    this.BookInformationService.find(+id).subscribe( res => {
      console.log(res);
      this.bookInformationId= res.bookInformationId,
      this.bookCategoryId=res.bookCategoryId,
      this.bookCategory=res.bookCategory,
      this.languageId = res.languageId,
      this.language = res.language,
      this.mainClassId= res.mainClassId,
      this.mainClass= res.mainClass,
      this.rowInfoId=res.rowInfoId,
      this.rowName = res.rowName,
      this.shelfInfoId= res.shelfInfoId,
      this.shelfName= res.shelfName,
      this.bookTitleInfoId=res.bookTitleInfoId,
      this.bookTitle = res.bookTitle,
      this.coverImage= res.coverImage,
      this.accessionNo= res.accessionNo,
      this.volume=res.volume,
      this.heading=res.heading,
      this.callNumber=res.callNumber,
      this.isbnNo=res.isbnNo,
      this.edition=res.edition
      this.issuable=res.issuable,
      this.pageNo=res.pageNo
      this.illustrations=res.illustrations,
      this.notes=res.notes
      this.price=res.price,
      this.sourceId=res.sourceId
      this.source=res.source,
      this.accessionDate=res.accessionDate
      this.useableDays=res.useableDays
      
    })
  }
  backClicked() {
    this._location.back();
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                    td{
                      padding-left:5px;
                    }
                  
                    .table.table-bordered-v tr .coverImage{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Book Information Details</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}
