import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {BookTitleInfoService} from '../../service/BookTitleInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { BookTitleInfo } from '../../models/BookTitleInfo';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-booktitleinfo',
  templateUrl: './new-booktitleinfo.component.html',
  styleUrls: ['./new-booktitleinfo.component.sass']
})
export class NewBookTitleInfoComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BookTitleInfoForm: FormGroup;
  validationErrors: string[] = [];
  departmentName:SelectedModel[];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','bookTitleName','titleBangla','bookSubtitle','remarks', 'actions'];
  dataSource: MatTableDataSource<BookTitleInfo> = new MatTableDataSource();
  selection = new SelectionModel<BookTitleInfo>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private BookTitleInfoService: BookTitleInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookTitleInfoId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Book Title';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookTitleInfoService.find(+id).subscribe(
        res => {
          this.BookTitleInfoForm.patchValue({          

            bookTitleInfoId: res.bookTitleInfoId,
            bookTitleName: res.bookTitleName,
            baseSchoolNameId:res.baseSchoolNameId,
            titleBangla: res.titleBangla,
            bookSubtitle: res.bookSubtitle,
            remarks: res.remarks,
            //menuPosition: res.menuPosition,
          
          });   
          this.getBookTitleInfos();  
           
        }
      );
    } else {
      this.pageTitle = 'Create Book Title';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.BookTitleInfoForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getBookTitleInfos(); 
  }
  intitializeForm() {
    this.BookTitleInfoForm = this.fb.group({
      bookTitleInfoId: [0],
      bookTitleName: [''],
      baseSchoolNameId:[''],
      titleBangla: [],
      bookSubtitle: [],
      remarks: [],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  getBookTitleInfos() {
    this.isLoading = true;
    this.BookTitleInfoService.getBookTitleInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.BookTitleInfoService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
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
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBookTitleInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBookTitleInfos();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.BookTitleInfoForm.get('bookTitleInfoId').value;   
    //this.BookTitleInfoForm.get('baseSchoolNameId').setValue(this.branchId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BookTitleInfoService.update(+id,this.BookTitleInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-booktitleinfo');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
    else {
      this.BookTitleInfoService.submit(this.BookTitleInfoForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/basic-setup/add-booktitleinfo');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.bookTitleInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.BookTitleInfoService.delete(id).subscribe(() => {
         // this.getCastes();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
          this.reloadCurrentRoute();
        })
      }
    })    
  }

}
