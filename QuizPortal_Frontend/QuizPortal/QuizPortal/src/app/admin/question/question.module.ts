import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { NgxPaginationModule } from "ngx-pagination";

import { QuestionComponent } from "./question.component";
import { Ng2SearchPipeModule } from "ng2-search-filter";
import { ModelModule } from "../../model/model.module";


@NgModule({
    imports:[CommonModule,ModelModule,FormsModule,NgxPaginationModule,Ng2SearchPipeModule],
    declarations:[QuestionComponent],
    exports:[QuestionComponent]
})

export class QuestionModule{

}