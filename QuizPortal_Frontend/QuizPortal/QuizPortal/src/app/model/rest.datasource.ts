import { Injectable } from "@angular/core";
import { catchError, from, Observable } from "rxjs";
import { QuestionGroup } from "./questiongroup.model";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Quiz } from "./quiz.model";
import { User } from "./user.model";
import { Question } from "./question.model";
import { Result } from "./result.model";

const PROTOCOL = "http";
const PORT = 10011
@Injectable()
export class RestDataSource {

    baseUrl: string;
    auth_token?: string;

    constructor(private http: HttpClient) {
        this.baseUrl = `${PROTOCOL}://${location.hostname}:${PORT}/`;
    }


    //User -- 
    GetAllUsers(): Observable<User[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<User[]>(this.baseUrl + "api/User", { headers: prodheaders });
    }

    GetUserForValidation(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + "api/User/Validate");
    }

    authenticate(user: string, pass: string): Observable<any> {
        return this.http.post<any>(this.baseUrl + "api/User/Authenticate", { UserName: user, Password: pass })
            .pipe(catchError((error) => {
                return error.message;
            }));
    }

    GetUserInfo(userName: string | null): Observable<User> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<User>(this.baseUrl + "api/User/id?name=" + userName, { headers: prodheaders });
    }

    public registerUser(user: User): Observable<any> {
        return this.http.post<any>(this.baseUrl + "api/User", user);
    }

    addUser(user: User): Observable<any> {
        console.log(user);
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.post<any>(this.baseUrl + "api/User/Add", user, { headers: prodheaders })
            .pipe(catchError((error) => {
                return error.message;
            }));
    }

    UpdateUser(id: any, user: User): Observable<any> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.put<any>(this.baseUrl + "api/User?id=" + id, user, { headers: prodheaders })
            .pipe(catchError((error) => {
                return error.message;
            }));
    }

    DeleteUser(id: any): Observable<any> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.delete<any>(this.baseUrl + "api/User/id?id=" + id, { headers: prodheaders })
            .pipe(catchError((error) => {
                return error.message;
            }));
    }

    //Question --
    GetAllQuestions(): Observable<Question[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Question[]>(this.baseUrl + "api/Question", { headers: prodheaders });

    }

    GetQuestionById(id: any): Observable<Question> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Question>(this.baseUrl + "api/Question/Id?id=" + id, { headers: prodheaders });
    }

    AddQuestion(question: Question): Observable<Question> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.post<any>(this.baseUrl + "api/Question", question, { headers: prodheaders });
    }

    DeleteQuestion(id: any): Observable<Question> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.delete<Question>(this.baseUrl + "api/Question/Id?id=" + id, { headers: prodheaders });
    }

    UpdateQuestion(id: any, question: Question): Observable<Question> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.put<Question>(this.baseUrl + "api/Question?id=" + id, question, { headers: prodheaders });
    }

    // QuestionGroup
    GetAllQuestionGroups(): Observable<QuestionGroup[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<QuestionGroup[]>(this.baseUrl + "api/questiongroup", { headers: prodheaders });
    }

    addQuestionGroup(questiongrp: QuestionGroup): Observable<any> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.post<any>(this.baseUrl + "api/questiongroup", questiongrp, { headers: prodheaders });

    }
    GetQuestionGroupById(id: any): Observable<QuestionGroup> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<QuestionGroup>(this.baseUrl + "api/QuestionGroup/Id?id=" + id, { headers: prodheaders });
    }

    DeleteQuestionGroup(id: any): Observable<QuestionGroup> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.delete<QuestionGroup>(this.baseUrl + "api/QuestionGroup/Id?id=" + id, { headers: prodheaders });
    }

    UpdateQuestionGroup(id: any, questiongrp: QuestionGroup): Observable<Question> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.put<Question>(this.baseUrl + "api/QuestionGroup?id=" + id, questiongrp, { headers: prodheaders });
    }

    //Quiz--
    GetAllQuizs(): Observable<Quiz[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Quiz[]>(this.baseUrl + "api/quiz", { headers: prodheaders });
    }

    GetQuizById(id: any): Observable<Quiz> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Quiz>(this.baseUrl + "api/Quiz/Id?id=" + id, { headers: prodheaders });
    }

    AddQuiz(quiz: Quiz): Observable<any> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.post<any>(this.baseUrl + "api/Quiz", quiz, { headers: prodheaders });
    }

    DeleteQuiz(id: any): Observable<Quiz> {
        console.log(id);
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.delete<Quiz>(this.baseUrl + "api/quiz/Id?id=" + id, { headers: prodheaders });

    }

    UpdateQuiz(id: any, quiz: Quiz): Observable<Quiz> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.put<Quiz>(this.baseUrl + "api/Quiz?id=" + id, quiz, { headers: prodheaders });

    }

    //Result--
    GetAllResults(): Observable<Result[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Result[]>(this.baseUrl + "api/Result", { headers: prodheaders }); // here json token is passed
    }

    GetResultById(id: any): Observable<Result> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Result>(this.baseUrl + "api/Result/" + id, { headers: prodheaders });
    }

    AddResult(result: Result): Observable<Result> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.post<any>(this.baseUrl + "api/Result", result, { headers: prodheaders });
    }

    GetResultByName(username: any): Observable<Result[]> {
        let token = sessionStorage.getItem("token");
        let prodheaders = new HttpHeaders().set("Authorization", "Bearer " + token);
        return this.http.get<Result[]>(this.baseUrl + "api/Result/username?username=" + username, { headers: prodheaders });
    }
}