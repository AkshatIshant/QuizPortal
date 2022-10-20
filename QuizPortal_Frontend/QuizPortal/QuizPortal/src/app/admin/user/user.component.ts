import { Component, OnInit } from '@angular/core';
import { NgForm,FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { RestDataSource } from '../../model/rest.datasource';
import { User } from '../../model/user.model';


@Component({
   selector: 'app-getusers',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  
  public users: User[] = [];
  public user_add=new User();
  public user_update=new User();
  public username: string ="";
  public user_delete=new User();
  public errorMessage?:string;
  public role: string | null = sessionStorage.getItem("role");
 //filter
 searchText:any;

     // pagination
     title = 'pagination';
     page:number=1;
     count:number=0;
     tableSize:number=5;
     tableSizes:any =[5,10,15,20];


  
  constructor(private datasource:RestDataSource, private router:Router) { 
  

}

userList():void{
  this.datasource.GetAllUsers().subscribe(data =>{
    this.users = data;
});

}

ngOnInit(): void { 

  this.userList();
 }
  addUser(form: NgForm) {

   
    console.log(form);
    this.datasource.addUser(this.user_add)
      .subscribe(response => {
        window.location.reload();
        this.router.navigateByUrl("/users");
      });
  
  }

    getUsername():string{
      return this.username;
    }

    updateId(user:any){
      this.user_update = user;
      console.log(this.user_update.id);
    }
  
    updateUserId(id:any){
      if(this.user_update.password==this.user_update.confirmPassword){
      this.datasource.UpdateUser(this.user_update.id,this.user_update).subscribe(reponse=>{
       window.location.reload(); 
      this.router.navigateByUrl("/users");
      })}
      else{
        this.errorMessage = "Passwords doesn't match!";
      }
      };

    deleteId(user:any){
      this.user_delete=user; 
    }
  
    deleteUserId(id:any){
      console.log(this.user_delete);
      this.datasource.DeleteUser(this.user_delete.id).subscribe(reponse=>{
             window.location.reload();
             this.router.navigateByUrl("/users");
        
      });
    }

    onTableDataChange(event:any){
      this.page=event;
      console.log(this.page);
      this.userList();
    }
    logout() {
      sessionStorage.removeItem("token");
      sessionStorage.removeItem("role");
      sessionStorage.removeItem("username");
      this.router.navigateByUrl("/");
      }
}


