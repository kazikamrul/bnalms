import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {MainClassService} from '../../service/MainClass.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-mainclass',
  templateUrl: './new-mainclass.component.html',
  styleUrls: ['./new-mainclass.component.sass']
})
export class NewMainClassComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  MainClassForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private MainClassService: MainClassService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('mainClassId'); 
    if (id) {
      this.pageTitle = 'Edit Main Class';
      this.destination='Edit';
      this.buttonText="Update";
      this.MainClassService.find(+id).subscribe(
        res => {
          this.MainClassForm.patchValue({          

            mainClassId: res.mainClassId,
            name: res.name,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Book Category';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.MainClassForm = this.fb.group({
      mainClassId: [0],
      name: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.MainClassForm.get('mainClassId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.MainClassService.update(+id,this.MainClassForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/mainclass-list');
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
      this.MainClassService.submit(this.MainClassForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/mainclass-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
