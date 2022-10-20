import { Component, Input, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

import { Router } from '@angular/router';
import { Question } from '../../model/question.model';
import { QuestionGroup } from '../../model/questiongroup.model';
import { RestDataSource } from '../../model/rest.datasource';





declare var window:any;

@Component({
  selector: 'app-questiondash',
  templateUrl: './question.component.html' ,
  styleUrls: ['./question.component.css']
})
export class QuestionComponent implements OnInit {

  formModal:any;
  public questions:Question[]=[];
  public question =new Question();
  public questionelement= new Question();
  public role: string | null = sessionStorage.getItem("role");

  public questiongroups:QuestionGroup[]=[];

   // pagination
   title = 'pagination';
   page:number=1;
   count:number=0;
   tableSize:number=4;
   tableSizes:any =[5,10,15,20];

   //filter
   searchText:any;


  constructor(private datasource:RestDataSource, private router:Router) {
    datasource.GetAllQuestionGroups().subscribe(data =>{
      this.questiongroups=data;
  })
  }
  questionList():void{
    this.datasource.GetAllQuestions().subscribe(data=>{
      this.questions=data;
      console.log(this.questions);

    });

  }

  ngOnInit(): void {
    this.questionList();
  }

  
  
  addQuestion(form:NgForm){
    if(form.valid){
        this.datasource.AddQuestion(this.question).subscribe(reponse=>{
            window.location.reload();
            // this.router.navigateByUrl("/");
        });
    }
  }

  deleteid(question:any){

    this.questionelement=question;
    console.log(question.id);

  }

  deletequesid(id:any){
    this.datasource.DeleteQuestion(this.questionelement.id).subscribe(reponse=>{
           window.location.reload();
          //  this.router.navigateByUrl("/");
      
    });
  }

  updateid(question:any){
    this.questionelement = question;
    console.log(this.questionelement.id);
  }

  updatequesid(id:any){

    this.datasource.UpdateQuestion(this.questionelement.id,this.questionelement).subscribe(reponse=>{
    window.location.reload(); 
    // this.router.navigateByUrl("/");

    });
  }

  // pagination code
  onTableDataChange(event:any){
    this.page=event;
    console.log(this.page);
    this.questionList();
  }

  
  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");
    }



}




