import { IClient } from './../models/Clients';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class ListClientService{
  private readonly USERS_API_URL = 'https://localhost:44360/api/users';

  constructor(private http: HttpClient){}

  public getClients(): Observable<IClient[]>{
    return this.http.get<IClient[]>(this.USERS_API_URL).pipe(
      tap(client => console.log('Users : ', client)),
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse){
    let errorMessage: string;

    if (error.error instanceof ErrorEvent) {
      errorMessage = `An error occurred : ${error.error.message}`;
    }else{
      errorMessage =
        `Backend return code ${error.status}, `+
        `body was : ${error.error}`;
    }

    return throwError(
      'Something bad happened; please try again later. \n '+ errorMessage
    );
  }
}
