import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import Swal from 'sweetalert2';
import { QuestionGroup } from '../../model/questiongroup.model';
import { Quiz } from '../../model/quiz.model';
import { RestDataSource } from '../../model/rest.datasource';

declare var window:any;
@Component({
  selector: 'questiongroupList',
  templateUrl: './questiongroup.component.html',
  styleUrls: ['./questiongroup.component.css']
})
 

export class QuestionGroupComponent implements OnInit{
    
  public questiongroups:QuestionGroup[]=[];
  public questiongroup= new QuestionGroup;
  public questiongrp = new QuestionGroup();
  public submitted: boolean = false; 
  public questiongrpelement=new QuestionGroup();

  public quizs:Quiz[]=[];

  // pagination
  title = 'pagination';
  page:number=1;
  count:number=0;
  tableSize:number=5;
  tableSizes:any =[5,10,15,20];

   //filter
   searchText:any;


  constructor(private router: Router,private datasource:RestDataSource){
      this.datasource.GetAllQuizs().subscribe(data=>{
        this.quizs=data;
        console.log(this.quizs);
    });
  }

  questiongroupList():void{
    this.datasource.GetAllQuestionGroups().subscribe(data =>{
      this.questiongroups=data;
      console.log(this.questiongroups);

    });

  }

  getQuestionGroupById(form:NgForm){
    if(form.valid){
        this.datasource.GetQuestionGroupById(this.questiongroup.id).subscribe(reponse=>{
            this.router.navigateByUrl('/getquestionGroupbyid');
            this.questiongroup=reponse;
        });
    }
}
  formModal:any;
  ngOnInit(): void {

   this.questiongroupList();
  }

  openModal(){
    this.formModal.show();
  }

  closeModal(){
    this.formModal.hide();
  }

  addQuestionGroup(form: NgForm) {
    if(form.valid) {
      this.datasource.addQuestionGroup(this.questiongrp)
        .subscribe(response => {
          //  this.router.navigateByUrl("/");
          window.location.reload();
          
        });
    }
  }

  deleteid(questiongroup:any){
    this.questiongrpelement=questiongroup;
    console.log(questiongroup.id)

  }

  deletequegrpid(id:any){
    this.datasource.DeleteQuestionGroup(this.questiongrpelement.id).subscribe(response=>{
      //  this.router.navigateByUrl("/questiongroup")
      window.location.reload();
      console.log(id)
    })

    // Swal.fire({
    //   title: 'Are you sure want to remove?',
    //   text: 'You will not be able to recover this file!',
    //   icon: 'warning',
    //   showCancelButton: true,
    //   confirmButtonText: 'Yes, delete it!',
    //   cancelButtonText: 'No, keep it'
    // }).then((result) => {
    //   if (result.value) {
    //     Swal.fire(
    //       'Deleted!',
    //       'Your imaginary file has been deleted.',
    //       'success'
    //     )
    //   } else if (result.dismiss === Swal.DismissReason.cancel) {
    //     Swal.fire(
    //       'Cancelled',
    //       'Your imaginary file is safe :)',
    //       'error'
    //     )
    //   }
    // })
    
  
  }
  
  
  updateid(questiongrp:any){
    this.questiongrpelement = questiongrp;
    console.log(this.questiongrpelement.id);
  }

  updatequesgrpid(id:any){

    this.datasource.UpdateQuestionGroup(this.questiongrpelement.id,this.questiongrpelement).subscribe(reponse=>{
    // this.router.navigateByUrl("/");
    window.location.reload();
    console.log(this.questiongrpelement.id);

    });
  }

   // pagination code
   onTableDataChange(event:any){
    this.page=event;
    console.log(this.page);
    this.questiongroupList();
  }

  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");
    }

}
