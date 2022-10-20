import { BehaviorSubject, Subject } from "rxjs";
import { Question } from "../model/question.model";
import { Quiz } from "../model/quiz.model";

export class ShareDataService {
    constructor() { }

    public quizQuestions: any = [];
    public quizElement? : any;
    public subject = new Subject<any>();
    public quizQueSource = new BehaviorSubject(this.quizQuestions);
    public quizeleSource = new BehaviorSubject(this.quizElement)

    currentQuiz = this.quizQueSource.asObservable();
    currentQuizelement = this.quizeleSource.asObservable();

    changeQuizQuestions(quizques: Question[]) {
        this.quizQueSource.next(quizques);
    }

    changeQuizelement(quizele: Quiz) {
        this.quizeleSource.next(quizele);
    }
}