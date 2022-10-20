import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { UserdashboardComponent } from './userdashboard/userdashboard.component';
import { QuizlistComponent } from './quizlist/quizlist.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { AppRoutingModule } from '../app-routing.module';
import { QuizStartModule } from './quizstart/quizstart.module';
import { ShareDataService } from './shareData.service';
import { UserResultComponent } from './userresult/userresult.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { UserResultModule } from './userresult/userresult.module';
import { Ng2SearchPipeModule } from 'ng2-search-filter';



@NgModule({
  imports: [
    CommonModule,FormsModule,AppRoutingModule,QuizStartModule,UserResultModule,
  ],
  declarations: [UserdashboardComponent, QuizlistComponent, UserprofileComponent],
 
  exports:[UserdashboardComponent,QuizlistComponent, UserprofileComponent],
  providers: [ShareDataService]
})
export class UserquizModule { }
