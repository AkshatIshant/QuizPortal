import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { ModelModule } from '../model/model.module';
import { RegisterComponent } from './register/register.component';
import { AppRoutingModule } from '../app-routing.module';



@NgModule({
  
  imports: [
    CommonModule,FormsModule,ModelModule,AppRoutingModule
  ],
  declarations: [LoginComponent,RegisterComponent],
  exports:[LoginComponent,RegisterComponent]
})
export class AccountModule { }
