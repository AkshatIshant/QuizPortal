import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestDataSource } from '../../model/rest.datasource';
import { User } from '../../model/user.model';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit {

  public user = new User()
  public userName : string | null = sessionStorage.getItem("username");

  
  

  constructor(private datasource:RestDataSource, private router:Router) { 
    datasource.GetUserInfo(this.userName).subscribe(data=>{
      this.user = data;
    }
    )
  }
  

  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");
    }

  ngOnInit(): void {
  }

}
