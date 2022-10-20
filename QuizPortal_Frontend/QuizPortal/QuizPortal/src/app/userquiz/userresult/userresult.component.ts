import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RestDataSource } from '../../model/rest.datasource';
import { Result } from '../../model/result.model';


@Component({
  selector: 'app-userresult',
  templateUrl: './userresult.component.html',
  styleUrls: ['./userresult.component.css']
})
export class UserResultComponent  implements OnInit{


  // public results:Result[]=[];

  public results:Result[]=[];

  public username?:string;

  public id?:number;
  
  public searchText:any;
  
  
  title = 'pagination';

  page: number=1;

  count:number=0;

  tableSize:number=5;

  tableSizes:any =[5,10,15,20];


  constructor(public datasource:RestDataSource, private router:Router) {
  
  }


  // getAll(){
  //   console.log("hello")
  // }
  
  resultList():void{

    //sessionStorage.setItem("username", "Akshat_001");
    this.datasource.GetResultByName(sessionStorage.getItem("username")).subscribe(response=>{
      this.results=response;
    // console.log("kitty moonee",sessionStorage.getItem("username"));
       
        console.log("responsokke sett",this.results);

      // this.router.navigateByUrl("/");
     });
   }
  
  
  
  
  
  
  ngOnInit(): void {
    //sessionStorage.setItem("username", "Akshat_001");
    this.datasource.GetResultByName(sessionStorage.getItem("username")).subscribe(response=>{
      this.results=response;
    // console.log("kitty moonee",sessionStorage.getItem("username"));
       
    //    console.log("responsokke sett",this.result);

      // this.router.navigateByUrl("/");
    });

    console.log(sessionStorage.getItem("username"));

    this.resultList();
    

     }
  
  reload(){
            console.log("hello");
           window.location.reload()
      }


      onTableDataChange(event:any){

        this.page=event;
      
        console.log(this.page);
      
        this.resultList();
      
      }

      logout() {
        sessionStorage.removeItem("token");
        sessionStorage.removeItem("role");
        sessionStorage.removeItem("username");
        this.router.navigateByUrl("/");
        }


    } 



