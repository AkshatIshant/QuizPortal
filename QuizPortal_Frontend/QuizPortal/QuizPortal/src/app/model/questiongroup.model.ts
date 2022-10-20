import { DatePipe} from "@angular/common";


export class QuestionGroup{
    constructor(
          public id?:number,
          public title?: string,
          public timeCreated?: Date,
          public timeUpdated?: Date,
          public quizTitle?: string
    ){ }
}