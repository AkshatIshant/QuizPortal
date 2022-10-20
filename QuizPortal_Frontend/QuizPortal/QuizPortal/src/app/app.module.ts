import { DatePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { AccountModule } from './account/account.module';
import { AdminModule } from './admin/admin.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DateChangePipe } from './pipes/date-change.pipe';
import { QuizstartComponent } from './userquiz/quizstart/quizstart.component';
import { QuizStartModule } from './userquiz/quizstart/quizstart.module';
import { UserquizModule } from './userquiz/userquiz.module';



@NgModule({
  declarations: [
    AppComponent
    
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AccountModule,
    AdminModule,
    UserquizModule,NgxPaginationModule,
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
