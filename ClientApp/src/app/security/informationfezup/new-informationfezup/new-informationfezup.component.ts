import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {InformationFezupService} from '../../service/InformationFezup.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-informationfezup',
  templateUrl: './new-informationfezup.component.html',
  styleUrls: ['./new-informationfezup.component.sass']
})
export class NewInformationFezupComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  InformationFezupForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private InformationFezupService: InformationFezupService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('informationFezupId'); 
    if (id) {
      this.pageTitle = 'Edit Information Fezup';
      this.destination='Edit';
      this.buttonText="Update";
      this.InformationFezupService.find(+id).subscribe(
        res => {
          this.InformationFezupForm.patchValue({          

            informationFezupId: res.informationFezupId,
            baseSchoolNameId: res.baseSchoolNameId,
            poNo: res.poNo,
            memberName: res.memberName,
            nationalId: res.nationalId,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Information Fezup';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.InformationFezupForm = this.fb.group({
      informationFezupId: [0],
      baseSchoolNameId: [''],
      poNo: [''],
      memberName: [''],
      nationalId: [''],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.InformationFezupForm.get('informationFezupId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.InformationFezupService.update(+id,this.InformationFezupForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/informationfezup-list');
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
      this.InformationFezupService.submit(this.InformationFezupForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/informationfezup-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
