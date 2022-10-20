import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgForm, UntypedFormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Result } from 'src/app/model/result.model';
import { Question } from '../../model/question.model';
import { QuestionGroup } from '../../model/questiongroup.model';
import { Quiz } from '../../model/quiz.model';
import { RestDataSource } from '../../model/rest.datasource';
import { ShareDataService } from '../shareData.service';

@Component({
  selector: 'app-quizstart',
  templateUrl: './quizstart.component.html',
  styleUrls: ['./quizstart.component.css']
})
export class QuizstartComponent implements OnInit {

  formModal: any;
  public quizs: Quiz[] = [];
  public quiz = new Quiz(new Date(),new Date());
  public quizelement = new Quiz(new Date(),new Date());
  public quizquestions: Question[] = [];
  public quizquestion?: Question;
  public questions: Question[] = [];
  public questiongroups: QuestionGroup[] = [];
  //public questiongroup?: QuestionGroup;
  public questiongroup: QuestionGroup[] = [];
  public len?: number;

  //one link
  public result = new Result("");
  public quizResult = new Quiz(new Date(),new Date());
  public disableQuiz : boolean = false;
  public results : Result[] = [];
  public userName: string | null = sessionStorage.getItem("username");




  constructor(private datasource: RestDataSource, private router: Router, private shareData: ShareDataService) {
    this.datasource.GetAllQuizs().subscribe(data => {
      this.quizs = data;
      console.log(this.quizs);
    });

    //one link
    this.datasource.GetAllResults().subscribe(data => {

      this.results = data;

    });
  }

  // child to parent data - 

  // @Output() parent :EventEmitter<any>=new EventEmitter();

  ngOnInit(): void {
    // this.parent.emit()
    // this.startQuiz(this.quiz);
  }

  ngAfterViewInit(): void {
    this.preparequiz(this.quiz);

  }


  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");
  }

  preparequiz(quiz: any): void {
    this.quizelement = quiz;
    this.quizquestions=[];

    this.datasource.GetAllQuestions().subscribe(data => {
      this.questions = data;
      // console.log(this.questions);


    });


    this.datasource.GetAllQuestionGroups().subscribe(data => {
      this.questiongroups = data;
      // console.log(this.questiongroups);

    });

  

    this.questiongroup = this.questiongroups.filter(q => {
      return q.quizTitle === this.quizelement.quizTitle;
    });

    console.log(this.questiongroup.length);

    //console.log('from quizstart - ', this.questions);

    var i: number;
    var vararr: Question[] = [];

    this.len = this.questiongroup.length;



      for (i = 0; i < this.len; i++) {

        vararr = this.questions.filter((ques) => {
          return ques.questionGroupTitle === this.questiongroup[i].title;
          
        });
        this.quizquestions = vararr.concat(this.quizquestions);
        
        
      }


      

      this.shareData.changeQuizQuestions(this.quizquestions);
      this.shareData.changeQuizelement(this.quizelement);

      //one link
      this.quizResult = this.quizelement;
      this.disableQuiz = false;



      for (let i = 0; i < this.results.length; i++) {      
        if ((this.results[i].userName == this.userName) && (this.results[i].quizTitle == this.quizResult.quizTitle)) {
          this.disableQuiz = true;  
  
        }      
  
    }

   
    console.log(this.quizquestions);
  }
  


  startQuiz() {

   
  }

  startExam() {
    this.router.navigateByUrl("/quizlist");
  }

}


