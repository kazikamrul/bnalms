import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VideoFileService } from '../../service/VideoFile.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { VideoFile } from '../../models/VideoFile';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { HttpEvent, HttpEventType  } from '@angular/common/http';
import {FileDialogMessageComponent} from '../file-dialog-message/file-dialog-message.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-new-videofiles',
  templateUrl: './new-videofiles.component.html',
  styleUrls: ['./new-videofiles.component.sass']
})
export class NewVideofilesComponent implements OnInit {
  masterData = MasterData;
  roleList = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  VideoFileForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse: SelectedModel[];
  selectedschool: SelectedModel[];
  selecteddocs: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selecteddownload: SelectedModel[];
  selectedVideoFileTitle: SelectedModel[];
  isShown: boolean = false;
  options = [];
  courseNameId: number;
  traineeId: any;
  role:any;
  loggedTraineeId:any;
  branchId:any;
  schoolId: any;
  baseSchoolNameId: number;
  VideoFileTitleId: number;
  VideoFileList: VideoFile[];
  public files: any[];
  progress: number = 0;
  btnShow=true;
  showSpinner=false;

  displayedColumns: string[] = ['ser', 'VideoFileTitle', 'documentName', 'documentType', 'document', 'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  filteredOptions;

  constructor(public dialog: MatDialog,private snackBar: MatSnackBar, private authService: AuthService,private confirmService: ConfirmService, private VideoFileService: VideoFileService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) {
    this.files = [];
  }

  ngOnInit(): void {
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    const id = this.route.snapshot.paramMap.get('videoFileId');

    this.role = this.authService.currentUserValue.role.trim();
    this.loggedTraineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)


    if (id) {
      this.pageTitle = 'Edit Video Files';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.VideoFileService.find(+id).subscribe(
        res => {
          console.log(res);
          this.VideoFileForm.patchValue({
            videoFileId:res.videoFileId,
            documentName: res.documentName,
            documentLink: res.documentLink,
         //   menuPosition: res.menuPosition,
          //  isActive: res.isActive
          });
          console.log("Response");
          console.log(res);
        }
      );
    } else {
      this.pageTitle = 'Create Video Files';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    // if(this.role != this.roleList.MasterAdmin){
    //   this.VideoFileForm.get('baseSchoolNameId').setValue(this.branchId);
    //   this.VideoFileForm.get('showRightId').setValue(this.branchId);
    // }
    this.getselectedschools();
  }
  intitializeForm() { 
    this.VideoFileForm = this.fb.group({
      //VideoFileId: [0],
      videoFileId:[0],
      documentName: [''],
      doc: [''],
      documentLink: [''],
      menuPosition: [''],
      isActive: [true]
    })
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file);
      if(file.size >2147483648){
        let tempDirection;
        if (localStorage.getItem('isRtl') === 'true') {
          tempDirection = 'rtl';
        } else {
          tempDirection = 'ltr';
        }
        const dialogRef = this.dialog.open(FileDialogMessageComponent, {
         // data: this.spareStockBySpRequest,
          direction: tempDirection,
        });
         this.btnShow=false;
         console.log("file size greater then 1Gb");
      }

      else{
        this.btnShow=true;
      }
      this.VideoFileForm.patchValue({
        doc: file,
      });
    }
  }

  getselectedschools() {
    this.VideoFileService.getselectedschools().subscribe(res => {
      this.selectedschool = res;
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.VideoFileForm.get('videoFileId').value;
    console.log(this.VideoFileForm.value)
    const formData = new FormData();
    for (const key of Object.keys(this.VideoFileForm.value)) {
      const value = this.VideoFileForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.VideoFileService.update(+id,formData).subscribe((event: HttpEvent<any>) => {
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
                }, 1500);
                // this.snackBar.open('Information Inserted Successfully ', '', {
                //   duration: 2000,
                //   verticalPosition: 'bottom',
                //   horizontalPosition: 'right',
                //   panelClass: 'snackbar-success'
                // });
                this.showSpinner =false;
                this.router.navigateByUrl('/book-management/videofile-list');
            }
            if(this.progress == 100){
              this.snackBar.open('Information Inserted Successfully ', '', {
                duration: 2000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
              this.router.navigateByUrl('/book-management/videofile-list');
              //this.reloadCurrentRoute();
            }
            // this.router.navigateByUrl('/book-management/videofile-list');
            // this.snackBar.open('Information Updated Successfully ', '', {
            //   duration: 2000,
            //   verticalPosition: 'bottom',
            //   horizontalPosition: 'right',
            //   panelClass: 'snackbar-success'
            // });
          }, error => {
            this.validationErrors = error;
          })
        }
        // {
        //   this.VideoFileService.update(+id, formData).subscribe(response => {
        //     if(this.traineeId){              
        //       const url = '/admin/dashboard/VideoFilelistinstructor/'+this.traineeId+'/'+this.schoolId;          
        //       this.router.navigateByUrl(url);
        //     }else{

        //       this.router.navigateByUrl('/book-management/VideoFile-list');
        //     }
        //     this.snackBar.open('Information Updated Successfully ', '', {
        //       duration: 2000,
        //       verticalPosition: 'bottom',
        //       horizontalPosition: 'right',
        //       panelClass: 'snackbar-success'
        //     });
        //   }, error => {
        //     this.validationErrors = error;
        //   })
        // }
      })
    } 
    else {
      console.log(this.VideoFileForm);
      this.VideoFileService.submit(formData).subscribe((event: HttpEvent<any>) => {

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
            }, 1500);
            // this.snackBar.open('Information Inserted Successfully ', '', {
            //   duration: 2000,
            //   verticalPosition: 'bottom',
            //   horizontalPosition: 'right',
            //   panelClass: 'snackbar-success'
            // });
            this.showSpinner =false;
            this.router.navigateByUrl('/book-management/videofile-list');
        }
       //this.reloadCurrentRoute();
        
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
          this.router.navigateByUrl('/book-management/videofile-list');
          //this.reloadCurrentRoute();
        }
      }, error => {
        this.validationErrors = error;
      });

      // if(this.traineeId){  
      //     const url = '/admin/dashboard/VideoFilelistinstructor/'+this.traineeId+'/'+this.schoolId;            
      //     this.router.navigateByUrl(url);
      //   }else{    
      //     this.router.navigateByUrl('/reading-materials/VideoFile-list');
      //   }

          // }, error => {
          //   this.validationErrors = error;
          // })
    
    // else {
    //   this.VideoFileService.submit(formData).subscribe(response => {
    //     console.log(this.VideoFileForm);
    //     if(this.traineeId){  
    //       const url = '/admin/dashboard/VideoFilelistinstructor/'+this.traineeId+'/'+this.schoolId;            
    //       this.router.navigateByUrl(url);
    //     }else{

    //       this.router.navigateByUrl('/reading-materials/VideoFile-list');
    //     }
    //     this.snackBar.open('Information Inserted Successfully ', '', {
    //       duration: 2000,
    //       verticalPosition: 'bottom',
    //       horizontalPosition: 'right',
    //       panelClass: 'snackbar-success'
    //     });
    //   }, error => {
    //     this.validationErrors = error;
    //   })
    // }

  // }
    }
  }
}
