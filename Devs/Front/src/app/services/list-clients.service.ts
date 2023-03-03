import { IClient } from './../models/Clients';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError, of } from "rxjs";
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

  public getClientsById(id: string): Observable<IClient>{
    const url = `${this.USERS_API_URL}?idInput=%7B${id}%7D`;

    if (!id) {
      return of(this.getDefaultHotel());
    }

    return this.http.get<IClient>(url).pipe(
      tap(client => console.log('User : ', client)),
      catchError(this.handleError)
    );
  }

  public createClient(client: IClient): Observable<IClient>{
    client = {
      ...client,
      Id: null
    }

    return this.http.post<IClient>(this.USERS_API_URL, client).pipe(
      catchError(this.handleError)
    );
  }

  public updateClient(client: IClient): Observable<IClient>{
    const url = `${this.USERS_API_URL}?update=%7B${client.Id}%7D`;
    return this.http.put<IClient>(url, client).pipe(
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

  private getDefaultHotel(): IClient{
    return {
      Id: null,
      FirstNameUser: null,
      LastNameUser: null,
      BirthDayUser: null,
      GenreUser: null,
    };
  }
}
