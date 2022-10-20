import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
// import { ModelModule } from "src/app/model/model.module";
import { NgxPaginationModule } from "ngx-pagination";


import { UserResultComponent } from "./userresult.component";
import { Ng2SearchPipeModule } from "ng2-search-filter";
import { ModelModule } from "../../model/model.module";
import { AppRoutingModule } from "../../app-routing.module";


@NgModule({
    imports:[CommonModule,ModelModule,FormsModule,NgxPaginationModule,Ng2SearchPipeModule,AppRoutingModule],
    declarations:[UserResultComponent],
    exports:[UserResultComponent]
})

export class UserResultModule{

}