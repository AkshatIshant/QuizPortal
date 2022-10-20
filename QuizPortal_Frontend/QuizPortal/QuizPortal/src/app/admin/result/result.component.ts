import { Component, OnInit } from '@angular/core';

import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";
import { RestDataSource } from '../../model/rest.datasource';
import { Result } from '../../model/result.model';



@Component({
  selector: 'app-resultdash',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.css']
})
export class ResultComponent implements OnInit {
  public results: Result[] = [];
  public res: Result[] = [];
  // public res:any=[];
  public id: any;
  // formModal:any;
  public username: any;

  searchText:any;


  // pagination
  title = 'pagination';
  page: number = 1;
  count: number = 0;
  tableSize: number = 5;
  tableSizes: any = [5, 10, 15, 20];


  constructor(private datasource: RestDataSource, private router: Router) {

  }




  checkhello() {
    console.log("hello")
  }



  searchid(username: any) {


    console.log(this.username)

    this.datasource.GetResultByName(this.username).subscribe(response => {

      this.res = response;
      console.log(this.res);
      //this.router.navigateByUrl("/result");

    });



  }


  resultList(): void {
    this.datasource.GetAllResults().subscribe(data => {



      this.results = data;
      console.log(this.results);

    });
  }




  ngOnInit(): void {

    this.resultList();


  }



  onTableDataChange(event: any) {

    this.page = event;

    console.log(this.page);

    this.resultList();

  }
  reload() {
    console.log("hello");
    window.location.reload()
  }

  logout() {
    sessionStorage.removeItem("token");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("username");
    this.router.navigateByUrl("/");

  }


}
