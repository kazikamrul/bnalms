import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {MemberCategoryService} from '../../service/MemberCategory.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-membercategory',
  templateUrl: './new-membercategory.component.html',
  styleUrls: ['./new-membercategory.component.sass']
})
export class NewMemberCategoryComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  MemberCategoryForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private MemberCategoryService: MemberCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('memberCategoryId'); 
    if (id) {
      this.pageTitle = 'Edit Member Category';
      this.destination='Edit';
      this.buttonText="Update";
      this.MemberCategoryService.find(+id).subscribe(
        res => {
          this.MemberCategoryForm.patchValue({          

            memberCategoryId: res.memberCategoryId,
            memberCategoryName: res.memberCategoryName,
            isActive: res.isActive

            // MemberCategoryId: res.MemberCategoryId,
            // MemberCategoryName: res.MemberCategoryName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Member Category';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.MemberCategoryForm = this.fb.group({
      memberCategoryId: [0],
      memberCategoryName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.MemberCategoryForm.get('memberCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.MemberCategoryService.update(+id,this.MemberCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/membercategory-list');
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
      this.MemberCategoryService.submit(this.MemberCategoryForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/membercategory-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
