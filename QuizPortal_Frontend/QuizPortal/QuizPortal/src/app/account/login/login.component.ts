import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RestDataSource } from '../../model/rest.datasource';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public username?: string;
  public password?: string;
  public token?: string;
  public errorMessage?: string;
  public role: string = "";
  public userName: string = ""

  constructor(private router: Router, private datasource: RestDataSource) { }

  authenticate(form: NgForm) {
    if (form.valid) {
      this.datasource.authenticate(this.username ?? "", this.password ?? "")
        .subscribe(response => {
          this.token = response.jwtToken;
          this.role = response.role;
          this.userName = response.userName;
          if (this.token != null) {
            sessionStorage.setItem("token", this.token);
            sessionStorage.setItem("role", this.role);
            sessionStorage.setItem("username", this.userName);

            if (this.role == "Admin") {
              this.router.navigateByUrl("/admindashboard");
            }
            else {
              this.router.navigateByUrl("/userdashboard");
            }
          }
          else {
            this.errorMessage = "Invalid username or password!";
          }
        })
    }
    else {
      this.errorMessage = "Both the fields are required";
    }
  }
}
