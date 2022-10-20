import { EmailValidator } from "@angular/forms";

export class User{
    public id?:number;
    public userName?:string;
    public password?:string;
    public confirmPassword?:string;
    public role?:string;
    public firstName?:string;
    public lastName?:string;
    public email?:EmailValidator;
    public contact?: number;

 constructor(id?:number,username?:string,password?:string,confirmpassword?:string,role?:string,
    firstname?:string,lastname?:string,email?:EmailValidator,contact?:number){
    this.id = id;
    this.userName = username;
   this.password = password;
   this.confirmPassword = confirmpassword;
   this.role = role;
   this.firstName = firstname;
     this.lastName = lastname;
     this.email = email;
     this.contact = contact;  
 }

}
