import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { ModelModule } from "../../model/model.module";

import { QuizstartComponent } from "./quizstart.component";





@NgModule({
    imports:[CommonModule,ModelModule,FormsModule],
    declarations:[QuizstartComponent],
    exports:[QuizstartComponent]
})

export class QuizStartModule{

}