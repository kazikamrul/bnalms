import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {RowInfoService} from '../../service/RowInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from '../../../core/models/selectedModel';

@Component({
  selector: 'app-new-rowinfo',
  templateUrl: './new-rowinfo.component.html',
  styleUrls: ['./new-rowinfo.component.sass']
})
export class NewRowInfoComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  RowInfoForm: FormGroup;
  validationErrors: string[] = [];
  selectedShelfInfo:SelectedModel[];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private RowInfoService: RowInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('rowInfoId'); 
    if (id) {
      this.pageTitle = 'Edit Row Info';
      this.destination='Edit';
      this.buttonText="Update";
      this.RowInfoService.find(+id).subscribe(
        res => {
          this.RowInfoForm.patchValue({          

            rowInfoId: res.rowInfoId,
            shelfInfoId:res.shelfInfoId,
            rowName: res.rowName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Row Info';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    this.getselectedShelfInfo();
  }
  intitializeForm() {
    this.RowInfoForm = this.fb.group({
      rowInfoId: [0],
      shelfInfoId:[''],
      rowName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  getselectedShelfInfo(){
    this.RowInfoService.getselectedShelfInfo().subscribe(res=>{
      this.selectedShelfInfo=res
    });
  }
  onSubmit() {
    const id = this.RowInfoForm.get('rowInfoId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.RowInfoService.update(+id,this.RowInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/rowinfo-list');
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
      this.RowInfoService.submit(this.RowInfoForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/rowinfo-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
