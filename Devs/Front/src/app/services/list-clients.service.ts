import { IClient } from './../models/Clients';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError, of } from "rxjs";
import {catchError, map, tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class ListClientService{
  private readonly CLIENT_API_URL = 'https://localhost:44360/api';

  constructor(private http: HttpClient){}

  public getClients(): Observable<IClient[]>{
    return this.http.get<IClient[]>(`${this.CLIENT_API_URL}/clients`).pipe(
      tap(client => console.log('Users Get All : ', client)),
      catchError(this.handleError)
    );
  }

  public getClientsById(id: string): Observable<IClient>{
    const url = `${this.CLIENT_API_URL}/clients?idInput=%7B${id}%7D`;

    if (!id) {
      return of(this.getDefaultHotel());
    }

    return this.http.get<IClient>(url).pipe(
      tap(client => console.log('Clients Get By Id : ', client)),
      catchError(this.handleError)
    );
  }

  public createClient(client: IClient): Observable<IClient>{
    client = {
      ...client,
      Id: null
    };

    return this.http.post<IClient>(this.CLIENT_API_URL, client).pipe(
      tap(client => console.log('Clients Created : ', client)),
      catchError(this.handleError)
    );
  }

  public updateClient(client: IClient): Observable<IClient>{
    const url = `${this.CLIENT_API_URL}/clients/update?idInput=%7B${client.Id}%7D`;
    return this.http.put<IClient>(url, client).pipe(
      tap(client => console.log('Clients Update : ', client)),
      catchError(this.handleError)
    );
  }

  public deleteClient(id: string): Observable<{}>{
    const url = `${this.CLIENT_API_URL}/clients/delete=?idInput=%7B${id}%7D`;

    return this.http.delete<IClient>(url).pipe(
      catchError(this.handleError)
    )
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
      FirstNameClient: null,
      LastNameClient: null,
      BirthDayClient: null,
      GenreClient: null,
    };
  }
}
