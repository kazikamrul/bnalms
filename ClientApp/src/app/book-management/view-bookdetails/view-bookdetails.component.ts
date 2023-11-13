import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BookInformation } from '../book-management-tab/models/BookInformation';
import { BookInformationService } from '../book-management-tab/service/BookInformation.service';
//import {BookInformation} from '../../'

@Component({
  selector: 'app-view-bookdetails',
  templateUrl: './view-bookdetails.component.html',
  styleUrls: ['./view-bookdetails.component.sass']
})
export class ViewBookDetailsComponent implements OnInit {

  masterData = MasterData;
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
    onlineSchlRequest: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.onlineSchlRequest = this.route.snapshot.paramMap.get('bookInformationId'); 
    this.BookInformationService.find(+this.onlineSchlRequest).subscribe( res => {
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
}
