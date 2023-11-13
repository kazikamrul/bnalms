import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {BulletinService} from '../../service/Bulletin.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-bulletin',
  templateUrl: './new-bulletin.component.html',
  styleUrls: ['./new-bulletin.component.sass']
})
export class NewBulletinComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  BulletinForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private BulletinService: BulletinService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bulletinId'); 
    if (id) {
      this.pageTitle = 'Edit Bulletin';
      this.destination='Edit';
      this.buttonText="Update";
      this.BulletinService.find(+id).subscribe(
        res => {
          this.BulletinForm.patchValue({          

            bulletinId: res.bulletinId,
            baseSchoolNameId: res.baseSchoolNameId,
            buletinDetails: res.buletinDetails,
            status: res.status,
            menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Bulletin';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.BulletinForm = this.fb.group({
      bulletinId: [0],
      baseSchoolNameId: [''],
      buletinDetails: [''],
      status: [''],
      menuPosition: [''],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.BulletinForm.get('bulletinId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BulletinService.update(+id,this.BulletinForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/bulletin-list');
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
      this.BulletinService.submit(this.BulletinForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/bulletin-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
