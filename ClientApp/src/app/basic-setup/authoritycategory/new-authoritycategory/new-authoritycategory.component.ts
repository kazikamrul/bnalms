import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {AuthorityCategoryService} from '../../service/AuthorityCategory.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-authoritycategory',
  templateUrl: './new-authoritycategory.component.html',
  styleUrls: ['./new-authoritycategory.component.sass']
})
export class NewAuthorityCategoryComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  AuthorityCategoryForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private AuthorityCategoryService: AuthorityCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('authorityCategoryId'); 
    if (id) {
      this.pageTitle = 'Edit Authority Category';
      this.destination='Edit';
      this.buttonText="Update";
      this.AuthorityCategoryService.find(+id).subscribe(
        res => {
          this.AuthorityCategoryForm.patchValue({          

            authorityCategoryId: res.authorityCategoryId,
            authorCategoryName: res.authorCategoryName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Authority Category';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.AuthorityCategoryForm = this.fb.group({
      authorityCategoryId: [0],
      authorCategoryName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.AuthorityCategoryForm.get('authorityCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.AuthorityCategoryService.update(+id,this.AuthorityCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/authoritycategory-list');
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
      this.AuthorityCategoryService.submit(this.AuthorityCategoryForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/authoritycategory-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
