import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {DesignationService} from '../../service/Designation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-designation',
  templateUrl: './new-designation.component.html',
  styleUrls: ['./new-designation.component.sass']
})
export class NewDesignationComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  DesignationForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private DesignationService: DesignationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('designationId'); 
    if (id) {
      this.pageTitle = 'Edit Designation';
      this.destination='Edit';
      this.buttonText="Update";
      this.DesignationService.find(+id).subscribe(
        res => {
          this.DesignationForm.patchValue({          

            designationId: res.designationId,
            designationName: res.designationName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Designation';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.DesignationForm = this.fb.group({
      designationId: [0],
      designationName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.DesignationForm.get('designationId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.DesignationService.update(+id,this.DesignationForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/designation-list');
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
      this.DesignationService.submit(this.DesignationForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/designation-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
