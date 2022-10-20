import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuestionGroupComponent } from './questiongroup.component';

import { NgxPaginationModule } from "ngx-pagination";
import { FormsModule } from '@angular/forms';
import { ModelModule } from '../../model/model.module';
import { Ng2SearchPipeModule } from 'ng2-search-filter';



@NgModule({
  imports:[ CommonModule,ModelModule,FormsModule,NgxPaginationModule,Ng2SearchPipeModule],
  declarations:[ QuestionGroupComponent],
  exports:[QuestionGroupComponent]
})
export class QuestiongroupModule { }
