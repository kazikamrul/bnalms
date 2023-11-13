import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {SoftCopyUploadService} from '../../service/SoftCopyUpload.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { SoftCopyUpload } from '../../models/SoftCopyUpload';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BookInformationService } from '../../book-management-tab/service/BookInformation.service';
import { Role } from 'src/app/core/models/role';
import { HttpEvent, HttpEventType  } from '@angular/common/http';

@Component({
  selector: 'app-new-softcopyupload',
  templateUrl: './new-softcopyupload.component.html',
  styleUrls: ['./new-softcopyupload.component.sass']
})
export class NewSoftCopyUploadComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  SoftCopyUploadForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
  selectedDocumentType:SelectedModel[];
  itemValue: string;
  options = [];
  filteredOptions;
  bookTitleInfoId:number;
  issuableToggle:string;
  bookInformationId: number;
  illustrationsToggle:string;
  getmemberinfoid: number;
  getmembername: string;
  bookTitleEnglish:any;
  bookTitleBangla:any;
  progress: number = 0;
  showSpinner=false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  }
  searchText="";

  ELEMENT_DATA: SoftCopyUpload[] = [];

  displayedColumns: string[] = [ 'sl','titleName','authorName','corporateAuthor','editor','storePDFFile', 'actions'];
  dataSource: MatTableDataSource<SoftCopyUpload> = new MatTableDataSource();

  selection = new SelectionModel<SoftCopyUpload>(true, []);

  constructor(private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private SoftCopyUploadService: SoftCopyUploadService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('softCopyUploadId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Soft Copy Upload';
      this.destination='Edit';
      this.buttonText="Update";
      this.SoftCopyUploadService.find(+id).subscribe(
        res => {
          this.SoftCopyUploadForm.patchValue({          

            softCopyUploadId: res.softCopyUploadId,
            baseSchoolNameId: res.baseSchoolNameId,
            titleName:res.titleName,
            authorName:res.authorName,
            corporateAuthor:res.corporateAuthor,
            editor:res.editor,
            storePDFFile:res.storePDFFile,
            documentTypeId:res.documentTypeId,
          
          });   
          //this.bookInformationId=res.bookInformationId;
        }
      );
    } else {
      this.pageTitle = 'Create Soft Copy Upload';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.SoftCopyUploadForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getSelectedDocumentType();
  }
  intitializeForm() {
    this.SoftCopyUploadForm = this.fb.group({
      softCopyUploadId: [0],
      baseSchoolNameId: [''],
      titleName:[''],
      authorName:[''],
      corporateAuthor:[''],
      editor: [''],
      storePDFFile: [''],
      doc:[''],
      isActive: [true],
      documentTypeId:[''],
     
    })
  }
  onDocumentTypeSelectionChange(){
    var documentTypeId = this.SoftCopyUploadForm.get('documentTypeId').value; 
    
    this.isLoading = true;
    this.SoftCopyUploadService.getSoftCopyUploadsByDocumentType(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.branchId,documentTypeId).subscribe(response => {
     
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log(this.dataSource.data);
    })
  }



  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
   // this.getSoftCopyUploads();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    //this.getSoftCopyUploads();
  } 

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log('dddd')
     console.log(file);
      this.SoftCopyUploadForm.patchValue({
        doc: file,
      });
    }
  }
  getSelectedDocumentType(){
    this.SoftCopyUploadService.getSelectedDocumentType().subscribe(res=>{
      this.selectedDocumentType=res
    }); 
  }
  GetDepartmentNameById(baseNameId){    
    this.SoftCopyUploadService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.SoftCopyUploadForm.get('softCopyUploadId').value;   
    //this.SoftCopyUploadForm.get('baseSchoolNameId').setValue(this.branchId);
    //console.log(this.SoftCopyUploadForm.value)
    const formData = new FormData();
    for (const key of Object.keys(this.SoftCopyUploadForm.value)) {
      const value = this.SoftCopyUploadForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.SoftCopyUploadService.update(+id,formData).subscribe(response => {
          this.reloadCurrentRoute();

            // this.router.navigateByUrl('/book-management/softcopyupload-list');
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
      this.SoftCopyUploadService.submit(formData).subscribe((event: HttpEvent<any>) => {
        console.log("event");
        switch (event.type) {
          case HttpEventType.Sent:
            console.log('Request has been made!');
            break;
          case HttpEventType.ResponseHeader:
            console.log('Response header has been received!');
            break;
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded / event.total * 100);
            console.log(`Uploaded! ${this.progress}%`);
            this.showSpinner=true;
            break;
          case HttpEventType.Response:
            console.log('User successfully created!', event.body);

            setTimeout(() => {
              this.progress = 0;
            }, 1500000);
            // this.snackBar.open('Information Inserted Successfully ', '', {
            //   duration: 2000,
            //   verticalPosition: 'bottom',
            //   horizontalPosition: 'right',
            //   panelClass: 'snackbar-success'
            // });
            this.showSpinner =false;
           // this.router.navigateByUrl('/book-management/softcopyupload-list');
        }
        
        // }, error => {
        //   this.validationErrors = error;
        // })

        if(this.progress == 100){
          this.snackBar.open('Information Inserted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        //  this.router.navigateByUrl('/book-management/softcopyupload-list');
          //this.reloadCurrentRoute();
        }
      }, error => {
        this.validationErrors = error;
      });
      this.reloadCurrentRoute();

      // this.SoftCopyUploadService.submit(formData).subscribe(response => {
        
        // this.router.navigateByUrl('/book-management/softcopyupload-list');
        // this.snackBar.open('Information Updated Successfully ', '', {
        //   duration: 2000,
        //   verticalPosition: 'bottom',
        //   horizontalPosition: 'right',
        //   panelClass: 'snackbar-success'
        // });
        // console.log("event.type")
      
     // }
      // , error => {
      //   this.validationErrors = error;
      // })
    }
 
  }
  

}
