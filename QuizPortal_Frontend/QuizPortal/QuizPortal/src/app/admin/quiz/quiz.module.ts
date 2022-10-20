import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { Ng2SearchPipeModule } from "ng2-search-filter";

import { NgxPaginationModule } from "ngx-pagination";
import { ModelModule } from "../../model/model.module";

import { QuizComponent} from "./quiz.component";


@NgModule({
    imports:[CommonModule,ModelModule,FormsModule,NgxPaginationModule,Ng2SearchPipeModule],
    declarations:[QuizComponent],
    exports:[QuizComponent]
})

export class QuizModule{

}