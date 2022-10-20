export class Result{

    public id?:number;

    public marksObtained?:number;

    public examDate?:Date;

    public  quizTitle?:string;

    public  userName?:string;

    constructor(id?:number,marksobtained?:number,examdate?:Date,quiztitle?:string,username?:string){

     this.id=id;

     this.marksObtained=marksobtained;

     this.examDate=examdate;

     this.quizTitle=quiztitle;

     this.userName=username;

    }

}