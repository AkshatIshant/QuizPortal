import { Component, OnInit } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { RestDataSource } from '../../model/rest.datasource';
import { User } from '../../model/user.model';

@Component({
  selector: 'app-adduser',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit{
  visible: boolean = true;
  changetype: boolean = true;
  public user = new User();
  public users: User[] = [];
  public submitted: boolean = true;
  public passwordConf: boolean = false;
  public duplicateUserName: boolean = false;

  constructor(private datasource: RestDataSource, private router: Router) {  
  }

ngOnInit(){
  this.datasource.GetUserForValidation()
  .subscribe(data=>{
      this.users=data;
  })
}

viewpass() {
  this.visible = !this.visible;
  this.changetype = !this.changetype;
}

addUser(form: NgForm) {
    if (form.valid) {
      this.datasource.addUser(this.user)
        .subscribe(response => {
          this.router.navigateByUrl("/users");
        });
    }
}

handleConfirmPasswordChange(form: NgForm) {
    if (this.user.password != this.user.confirmPassword) {
      this.passwordConf = true;
      return;
    }
    else {
      this.passwordConf = false;
    }
}

usernameCheck(form: NgForm) {
    var empList = this.users.map(x => x.userName)
    for (let i = 0; i < empList.length; i++) {
      if (empList[i] != this.user.userName) {
        this.duplicateUserName = false;
      }
      else {
        this.duplicateUserName = true;
        return;
      }
    }
}

registerUser(form: NgForm) {
    this.submitted = false;

    if (this.user.password != this.user.confirmPassword) {
      this.passwordConf = true;
      return;
    }
    else {
      this.passwordConf = false;
    }
    if (form.valid) {

      this.user.role = "Candidate";
      this.datasource.registerUser(this.user)
        .subscribe(response => {
          //console.log(response.headers.status)
          if (response.id != undefined) {
            this.duplicateUserName = false;
            this.router.navigateByUrl("/")
          }
          else {
            this.duplicateUserName = true;
          }
        })
      this.submitted = true;
    }
  }
}















