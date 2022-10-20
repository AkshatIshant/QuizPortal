import { LocationStrategy } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { interval } from 'rxjs';
import Swal from 'sweetalert2';
import { Question } from '../../model/question.model';
import { QuestionGroup } from '../../model/questiongroup.model';
import { Quiz } from '../../model/quiz.model';
import { RestDataSource } from '../../model/rest.datasource';
import { Result } from '../../model/result.model';
import { ShareDataService } from '../shareData.service';
// import { Chart, registerables } from 'chart.js';
// Chart.register(...registerables)

@Component({
  selector: 'app-quizlist',
  templateUrl: './quizlist.component.html',
  styleUrls: ['./quizlist.component.css']
})
export class QuizlistComponent implements OnInit {

  public _name: string = "";

  public currentQuestion: number = 0;
  public points: number = 0;
  counter = 60;
  public correctAnswer?: any = 0;

  interval$: any;
  progress: string = "0";
  isQuizCompleted: boolean = false;
  q: any;
  i: any;
  mark: any;

  // quizstart component se data call 

  public quizs: Quiz[] = [];
  public quiz = new Quiz(new Date(), new Date());
  public quizelement = new Quiz(new Date(), new Date());
  public quizquestions: any = [];
  public quizquestion?: Question;
  public questions: Question[] = [];
  public questiongroups: QuestionGroup[] = [];
  public questiongroup?: QuestionGroup;
  public userName: string | null = sessionStorage.getItem("username");
  public quizTimer: any;
  public today = new Date();
  public result = new Result("");
  public pageRefreshed:boolean=false;



  public startTime: Date = new Date();
  public endTime: Date = new Date();
  public duration: any | undefined;


  // marks calculation
  inCorrectAnswer: number = 0;
  marksGot = 0;
  correctAnswers = 0;
  attemted = 0;
  totalMarks: any = 0;
  timer: any;

  //one link
  
   //chart
  // public Chart:any=[];
  // public cCount:any= sessionStorage.getItem("username");


  constructor(private datasource: RestDataSource, private router: Router, private shareData: ShareDataService, private locationSt: LocationStrategy) {


  }




  ngOnInit(): void {
    this.result.userName = sessionStorage.getItem("username");
    this.result.examDate = this.today;
    this._name = localStorage.getItem("name")!;
    this.shareData.currentQuiz.subscribe(l => {
      this.quizquestions = l;

      l.forEach((q: any) => {
        q["givenAnswer"] = ""

      });
    });
    this.shareData.currentQuizelement.subscribe(q => {
      this.quizelement = q;
      this.result.quizTitle = this.quizelement.quizTitle;
      //ne date
      this.endTime = new Date(this.quizelement.endTime);

      this.startTime = new Date(this.quizelement.startTime)
    });

    this.duration = this.endTime.valueOf() - this.startTime.valueOf();

    this.quizTimer = this.duration / 1000;
    //this.quizTimer = 310;
    




     this.preventBackButton();
    this.startTimer();
    // this.getQuestions();

    // this.startCounter();

    this.startAllCounter();
    if (this.duration === 0) {

      this.pageRefreshed = true;
    
      console.log(this.pageRefreshed, "dtetette", "this.duration", this.duration);
    
    
    
    }


    


  }

  preventBackButton() {
    history.pushState(null, "null", location.href);
    this.locationSt.onPopState(() => {
      history.pushState(null, "null", location.href);
    });

  }


  getQuestions() {
  }
  nextQuestion() {
    this.currentQuestion++;

  }
  previousQuestion() {
    this.currentQuestion--;

  }
  answer(currentQno: number, option: any) {


    if (currentQno === this.quizquestions.length) {
      this.isQuizCompleted = true;
      this.stopCounter();
    }
    if (option) {
      this.points += 10;
      this.correctAnswer++;

      setTimeout(() => {
        // this.currentQuestion++;
        // this.resetCounter();
        this.getProgressPercent();
      }, 1000);


    } else {

      setTimeout(() => {
        // this.currentQuestion++;
        this.inCorrectAnswer++;
        // this.resetCounter();
        this.getProgressPercent();
      }, 1000);

      // this.points -= 10;
    }
  }
  marksBasis() {
    if (this.quizquestions[this.currentQuestion].difficultyLevel == "Easy") {
      this.mark = 2;

      return this.mark;
    }
    else if (this.quizquestions[this.currentQuestion].difficultyLevel == "Medium") {
      this.mark = 3;
      return this.mark;
    }
    else {
      this.mark = 5;
      return this.mark;
    }
  }
  totalQuizMark(): any {
    this.totalMarks = 0;
    this.quizquestions.forEach((q: any) => {
      if (q.difficultyLevel == "Easy") {
        this.totalMarks += 2;

      }
      else if (q.difficultyLevel == "Medium") {
        this.totalMarks += 3;

      }
      else {
        this.totalMarks += 5;

      }
    });
    return this.totalMarks;
  }


  marksCalculation() {
    this.quizquestions.forEach((q: any) => {
      if (q.givenAnswer != "") {
        this.attemted += 1;
        if (q.givenAnswer == q.correctAnswer) {
          this.correctAnswer++;
          if (q.difficultyLevel == "Easy") {
            this.marksGot += 2;
          }
          else if (q.difficultyLevel == "Medium") {
            this.marksGot += 3;
          }
          else {
            this.marksGot += 5;
          }

        }
       
      }
      this.inCorrectAnswer = this.attemted - this.correctAnswer
    });
    this.result.marksObtained = this.marksGot;
  }

  evalQuiz() {
    this.marksCalculation();
    Swal.fire({

      icon: 'success',
      title: 'Your work has been saved',
      showConfirmButton: false,
      timer: 2000
    })
    setTimeout(() => {
      this.isQuizCompleted = true;
    }, 2000);
  }
  startTimer() {
    var t: any = window.setInterval(() => {
      if (this.quizTimer <=0 && !this.pageRefreshed)  {

        clearInterval(t);
console.log("after refresing");
        this.autoSubmit();
      }
      else {
        if (this.isQuizCompleted || this.pageRefreshed) {

          clearInterval(t);
          

        }
        this.quizTimer--;
        console.log(this.quizTimer)
      }
    }, 1000)
  }
  getFormattedTime() {
    let mm = Math.floor(this.quizTimer / 60)
    let ss = this.quizTimer - mm * 60
    return `${mm}min:${ss}sec`;
  }
  getProgressPercent() {

    this.progress = ((this.currentQuestion / this.quizquestions.length) * 100).toString();
    return this.progress;

  }

  autoSubmit() {
    Swal.fire({
      title: 'Time is over!.Your test has been submitted.',
      confirmButtonText: 'Continue',
      denyButtonText: `Don't save`,
      icon: "info"
    }).then((e: any) => {
      if (e.isConfirmed) {
       
       
        this.marksCalculation();
        this.isQuizCompleted = true;
       // Swal.fire('Saved!', '', 'success');
        // setTimeout(() => {
        //   this.isQuizCompleted = true;
        // }, 2000);
      }
      console.log(this.correctAnswer, this.marksGot, this.attemted);
      console.log(this.totalQuizMark());
      this.datasource.AddResult(this.result)
      .subscribe(response => {
        
      });
      return this.isQuizCompleted

    });



  }

  onSubmit() {
    Swal.fire({
      title: 'Do you want to submit the quiz?',
      showCancelButton: true,
      confirmButtonText: 'Submit',
      denyButtonText: `Don't save`,
      icon: "info"
    }).then((e: any) => {
      if (e.isConfirmed) {
        console.log("e.isConfirmed");
        console.log(this.quizquestions);
        this.marksCalculation();
        this.isQuizCompleted = true;
      
        // setTimeout(() => {
        //   this.isQuizCompleted = true;
        // }, 2000);
      }
      console.log(this.correctAnswer, this.marksGot, this.attemted);
      console.log(this.totalQuizMark(), "this is the total marks of given quiz");
      console.log(this.today);
      this.datasource.AddResult(this.result)
      .subscribe(response => {
        
      });
      return this.isQuizCompleted

    });



  }



  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");
  }

  startAllCounter() {
    this.interval$ = interval(100000000)
      .subscribe(val => {
        this.counter--;
        if (this.counter === 0) {
          // this.submit()

        }
      })

  }

  stopCounter() {
    this.interval$.unsubscribe();
    this.counter = 0;
  }

}