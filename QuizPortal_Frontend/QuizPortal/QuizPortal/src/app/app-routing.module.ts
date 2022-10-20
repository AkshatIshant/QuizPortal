import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { AdmindashboardComponent } from './admin/admindashboard/admindashboard.component';
import { QuestionComponent } from './admin/question/question.component';
import { QuestionGroupComponent } from './admin/questiongroup/questiongroup.component';
import { QuizComponent } from './admin/quiz/quiz.component';
import { ResultComponent } from './admin/result/result.component';
import { UserComponent } from './admin/user/user.component';
import { QuizlistComponent } from './userquiz/quizlist/quizlist.component';
import { QuizstartComponent } from './userquiz/quizstart/quizstart.component';

import { UserdashboardComponent } from './userquiz/userdashboard/userdashboard.component';
import { UserprofileComponent } from './userquiz/userprofile/userprofile.component';
import { UserResultComponent } from './userquiz/userresult/userresult.component';


const routes: Routes = [
  {path:'',component:LoginComponent},
  { path: 'admindashboard', component: AdmindashboardComponent },
  { path: 'users', component: UserComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'question', component: QuestionComponent },
  { path: 'questiongroup', component: QuestionGroupComponent },
  { path: 'quiz', component: QuizComponent },
  {path:'result',component:ResultComponent},
  {path:'userdashboard',component:UserdashboardComponent},
  {path:'quizlist',component:QuizlistComponent},
  {path:'userprofile',component:UserprofileComponent},
  {path:'quizstart',component:QuizstartComponent},
  {path:'userresult',component:UserResultComponent},
  {path:"**",redirectTo:"/"}  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
