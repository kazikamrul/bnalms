import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {ShelfInfoService} from '../../service/ShelfInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-shelfinfo',
  templateUrl: './new-shelfinfo.component.html',
  styleUrls: ['./new-shelfinfo.component.sass']
})
export class NewShelfInfoComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  ShelfInfoForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private ShelfInfoService: ShelfInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('shelfInfoId'); 
    if (id) {
      this.pageTitle = 'Edit Shelf Info';
      this.destination='Edit';
      this.buttonText="Update";
      this.ShelfInfoService.find(+id).subscribe(
        res => {
          this.ShelfInfoForm.patchValue({          

            shelfInfoId: res.shelfInfoId,
            shelfName: res.shelfName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Shelf Info';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.ShelfInfoForm = this.fb.group({
      shelfInfoId: [0],
      shelfName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.ShelfInfoForm.get('shelfInfoId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.ShelfInfoService.update(+id,this.ShelfInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/shelfinfo-list');
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
      this.ShelfInfoService.submit(this.ShelfInfoForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/shelfinfo-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
