import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { User } from './../user';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  GetUserTestData() {
    return [
      { "id": 12, "First Name": 'Mahesh', "Last Name": 'selvaraj', "DOB": '06-06-1984' },
      { "id": 13, "First Name": 'Suresh', "Last Name": 'kumar', "DOB": '06-08-1988' }
    ];
  }

  GetUsers() : Observable<User[]> {
    return this.http.get<User[]>('http://localhost:61/api/users').pipe(      
      catchError(this.errormessagehandler)
    );
  }

  AddUser() {
    //this.http.post<User>();
  }

  GetUser(userid: string): Observable<User> {
    return this.http.get<User>('http://localhost:61/api/user' + userid).pipe(
      catchError(this.errormessagehandler)
    );
  }


  errormessagehandler(error: HttpErrorResponse) {
    return throwError(error.message || "error");
  }

}


