import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AppUserService } from 'src/app/@core/services/admin/app-user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  appUsers: any;
  appUsersData: any;

  constructor(
    private appUserService: AppUserService
  ) { }

  ngOnInit(): void {
    this.GetAllAppUser();
  }

  GetAllAppUser(){
    this.appUserService.GetAllUser().subscribe((x: HttpResponse<any>) => {
      if (x.status == 200) {
        this.appUsers = x.body;
        this.appUsersData = this.appUsers.data;
        console.log("On a " , this.appUsersData);
        console.log("On a body " , this.appUsers);
      }
      else{
        console.log("Non status 200");
      }
    })
  }

}
