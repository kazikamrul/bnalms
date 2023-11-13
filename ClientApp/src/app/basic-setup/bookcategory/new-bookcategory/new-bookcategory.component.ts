import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {BookCategoryService} from '../../service/BookCategory.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-new-bookcategory',
  templateUrl: './new-bookcategory.component.html',
  styleUrls: ['./new-bookcategory.component.sass']
})
export class NewBookCategoryComponent implements OnInit {
  buttonText:string;
  pageTitle: string;
  destination:string;
  BookCategoryForm: FormGroup;
  validationErrors: string[] = [];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private BookCategoryService: BookCategoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookCategoryId'); 
    if (id) {
      this.pageTitle = 'Edit Book Category';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookCategoryService.find(+id).subscribe(
        res => {
          this.BookCategoryForm.patchValue({          

            bookCategoryId: res.bookCategoryId,
            bookCategoryName: res.bookCategoryName,
            remark:res.remark,
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
    this.BookCategoryForm = this.fb.group({
      bookCategoryId: [0],
      bookCategoryName: [''],
      remark:[""],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
  
  onSubmit() {
    const id = this.BookCategoryForm.get('bookCategoryId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BookCategoryService.update(+id,this.BookCategoryForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/bookcategory-list');
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
      this.BookCategoryService.submit(this.BookCategoryForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/basic-setup/bookcategory-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }

}
