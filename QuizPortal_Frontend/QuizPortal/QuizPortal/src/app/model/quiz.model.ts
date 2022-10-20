

export class Quiz{

    public id?:number;
    public quizTitle?:string;
    public description?: string;
    public startTime: Date;
    public endTime: Date;

    constructor(startTime:Date,endTime:Date){
    this.startTime = startTime;
    this.endTime = endTime;
    }
}