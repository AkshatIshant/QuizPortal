import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user/user.component';
import { FormsModule } from '@angular/forms';
import { QuestiongroupModule } from './questiongroup/questiongroup.module';
import { QuestionModule } from './question/question.module';
import { QuizModule } from './quiz/quiz.module';
import { AppRoutingModule } from '../app-routing.module';
import { AdmindashboardComponent } from './admindashboard/admindashboard.component';
import { DateChangePipe } from '../pipes/date-change.pipe';
import { ResultComponent } from './result/result.component';
import { NgxPaginationModule } from "ngx-pagination";
import { Ng2SearchPipeModule } from 'ng2-search-filter';



@NgModule({
  imports: [
    CommonModule,FormsModule,QuestiongroupModule,QuestionModule,QuizModule,AppRoutingModule,NgxPaginationModule,Ng2SearchPipeModule
  ],
  providers:[DateChangePipe],
  declarations: [UserComponent,AdmindashboardComponent,DateChangePipe,ResultComponent],
  exports: [UserComponent,AdmindashboardComponent,ResultComponent ]
})
export class AdminModule { }
