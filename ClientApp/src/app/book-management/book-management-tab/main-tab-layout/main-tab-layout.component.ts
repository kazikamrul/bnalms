import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {ChildParameterService} from '../service/ChildParameter.service'
//import {ChildParameterService} from './service/ChildParameter.service'

@Component({
  selector: 'app-main-tab-layout',
  templateUrl: './main-tab-layout.component.html',
  styleUrls: ['./main-tab-layout.component.sass']
})
export class MainTabLayoutComponent implements OnInit {

  
  
  title = 'angular-material-tab-router';  
  navLinks: any[];
  id: any;
  activeLinkIndex = -1; 
  constructor(private router: Router, private route: ActivatedRoute, private childParameterService: ChildParameterService) {
    
    this.navLinks = [
        // {
        //   label: 'Book Info',
        //   link: '../main-tab/update-bookinformation/',
        //   index: 0
        // },

        {
          label: 'Author Info',
          link: '../main-tab/authornformation',
          index: 1
        }, 

        {
          label: 'Publisher Info',
          link: '../main-tab/publishersinformation',
          index: 2
        }, 

        {
          label: 'Supplier Info',
          link: '../main-tab/supplierinformation',
          index: 3
        }, 
        {
          label: 'Source Info',
          link: '../main-tab/sourceinformation',
          index: 3
        }, 

       
        
      ];
  }
  ngOnInit(): void {
   
    this.id = this.route.snapshot.paramMap.get('bookInformationId');
    //this.id = 17;
    if (this.id) {
      this.childParameterService.SetupTraineeId(this.id);
    }
    else{
      if (this.childParameterService.currentTraineeValue) {
        this.id = this.childParameterService.currentTraineeValue;
      }
    }
  
    
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
  }


}
