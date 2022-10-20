import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { bootstrapApplication } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Quiz } from '../../model/quiz.model';
import { RestDataSource } from '../../model/rest.datasource';

declare var window:any;
@Component({
  selector: 'quizdashboard',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {
    formModal:any;
    public quizs:Quiz[]=[];
    public quiz =new Quiz(new Date(),new Date());
    public quizelement= new Quiz(new Date(),new Date());

    // pagination
  title = 'pagination';
  page:number=1;
  count:number=0;
  tableSize:number=5;
  tableSizes:any =[5,10,15,20];

   //filter
   searchText:any;
  
    constructor(private datasource:RestDataSource, private router:Router) {
      this.datasource.GetAllQuizs().subscribe(data=>{
        this.quizs=data;
        console.log(this.quizs);
    });
     }

     quizList():void{
        this.datasource.GetAllQuizs().subscribe(data=>{
          this.quizs=data;
          console.log(this.quizs);
      });
  
    }
    
    ngOnInit(): void { 

      this.quizList();
     }
    openModal(){
      this.formModal.show();
    }
  
    closeModal(){
      this.formModal.hide();
    }
    
    addQuiz(form:NgForm){
      if(form.valid){
          this.datasource.AddQuiz(this.quiz).subscribe(reponse=>{
            console.log("Reached reload");
            window.location.reload();  
            //this.router.navigateByUrl("/quiz");
          });
      }
    }

    deleteid(quiz:any){

      this.quizelement=quiz;
      console.log(this.quizelement.id)
  
    }

    deletequizid(id:any){
      this.datasource.DeleteQuiz(this.quizelement.id).subscribe(reponse=>{
             window.location.reload();
            //this.router.navigateByUrl("/quiz");
        
      });
    }

    updateid(quiz:any){
      this.quizelement = quiz;
      console.log(this.quizelement.id);
    }

    updatequizid(id:any){

      this.datasource.UpdateQuiz(this.quizelement.id,this.quizelement).subscribe(reponse=>{
      window.location.reload(); 
      console.log(this.quizelement.id);
      //this.router.navigateByUrl("/quiz");
  
      });
    }

    // pagination code
   onTableDataChange(event:any){
    this.page=event;
    console.log(this.page);
    this.quizList();
  }

    logout() {
      sessionStorage.removeItem("token");
      sessionStorage.removeItem("role");
      sessionStorage.removeItem("username");
      this.router.navigateByUrl("/");
      }
    
  }
