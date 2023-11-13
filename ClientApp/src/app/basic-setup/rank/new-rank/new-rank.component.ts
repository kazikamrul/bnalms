import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {RankService} from '../../service/Rank.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-new-rank',
  templateUrl: './new-rank.component.html',
  styleUrls: ['./new-rank.component.sass']
})
export class NewRankComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  RankForm: FormGroup;
  selectedDesignation:SelectedModel[];
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private RankService: RankService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('rankId'); 
    if (id) {
      this.pageTitle = 'Edit Rank';
      this.destination='Edit';
      this.buttonText="Update";
      this.RankService.find(+id).subscribe(
        res => {
          this.RankForm.patchValue({          

            rankId: res.rankId,
            designationId:res.designationId,
            rankName: res.rankName,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Rank';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    this.getselectedDesignation();
  }
  intitializeForm() {
    this.RankForm = this.fb.group({
      rankId: [0],
      designationId:[''],
      rankName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  getselectedDesignation(){
    this.RankService.getselectedDesignation().subscribe(res=>{
      this.selectedDesignation=res
    });
  }
  onSubmit() {
    const id = this.RankForm.get('rankId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.RankService.update(+id,this.RankForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/rank-list');
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
      this.RankService.submit(this.RankForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/rank-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
