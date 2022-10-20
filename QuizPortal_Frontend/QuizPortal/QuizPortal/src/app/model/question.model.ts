export class Question{
    public id?: number;
    public questionText?: String;
    public option1?: string;
    public option2?: string;
    public option3?: string;
    public option4?: string;
    public correctAnswer?: string;
    public difficultyLevel?:string;
    public questionGroupTitle?: string;
    public timeCreated?: Date;
    public timeUpdated?: Date;

    constructor(id?:number,text?:string,op1?:string,op2?:string,op3?:string,op4?:string,ans?:string,level?:string,timecreate?:Date,timeupdate?:Date,grouptitle?:string){
        this.id=id;
        this.questionText=text;
        this.option1=op1;
        this.option2=op2;
        this.option3=op3;
        this.option4=op4;
        this.correctAnswer=ans;
        this.difficultyLevel=level;
        this.questionGroupTitle=grouptitle;
        this.timeCreated=timecreate;
        this.timeUpdated=timeupdate;

    }
}