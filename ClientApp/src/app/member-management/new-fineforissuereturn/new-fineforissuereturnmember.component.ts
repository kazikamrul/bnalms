import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
// import {CourseTypeService} from '../../service/CourseType.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { FineForIssueReturn } from 'src/app/basic-setup/models/FineForIssueReturn';
import { FineForIssueReturnService } from 'src/app/basic-setup/service/FineForIssueReturn.service';

@Component({
  selector: 'app-new-fineforissuereturnmember',
  templateUrl: './new-fineforissuereturnmember.component.html',
  styleUrls: ['./new-fineforissuereturnmember.component.sass']
})
export class NewFineforIssueReturnMemberComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  CourseTypeForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private FineForIssueReturnService: FineForIssueReturnService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('fineForIssueReturnId'); 
    if (id) {
      this.pageTitle = 'Fine For Issue return';
      this.destination='Edit';
      this.buttonText="Update";
      this.FineForIssueReturnService.find(+id).subscribe(
        res => {
          this.CourseTypeForm.patchValue({          

            fineForIssueReturnId: res.fineForIssueReturnId,
            baseSchoolNameId: res.baseSchoolNameId,
            amount: res.amount,
            menuPosition: res.menuPosition,
            isActive: res.isActive    
          });          
        }
      );
    } else {
      this.pageTitle = 'Fine For Issue return';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.CourseTypeForm = this.fb.group({
      fineForIssueReturnId: [0],
      baseSchoolNameId: [''],
      amount: [],
      bookIssueAndSubmissionId:[],
      // menuPosition: [],
      // isActive: true    
    })
  }
  
  onSubmit() {
    const id = this.CourseTypeForm.get('fineForIssueReturnId').value;  
    var baseSChoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');  
    var bookIssueAndSubmissionId = this.route.snapshot.paramMap.get('bookIssueAndSubmissionId'); 
    this.CourseTypeForm.get('baseSchoolNameId').setValue(baseSChoolNameId);
    this.CourseTypeForm.get('bookIssueAndSubmissionId').setValue(bookIssueAndSubmissionId);

  var ba=this.CourseTypeForm.get('bookIssueAndSubmissionId').value;
  console.log(ba);
      this.FineForIssueReturnService.submit(this.CourseTypeForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/member-management/fineforissuereturn-list');
      }, error => {
        this.validationErrors = error;
      })
  }

}
