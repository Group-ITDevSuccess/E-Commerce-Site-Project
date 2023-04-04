import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from "@angular/common/http";
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { Injectable } from '@angular/core';

const baseUrl = 'http://localhost:4200/api';
@Injectable()

export class ApiService{

  constructor(private http: HttpClient){}

  private formatErrors(error: any){
    return throwError(error.error);
  }

  post<T>(path: string, body: Object = {}): Observable<HttpResponse<T> | Observable<never>>{
    return this.http.post<T>(`${environment.api_host}${path}`, JSON.stringify(body), {observe: 'response'})
      .pipe(catchError(this.formatErrors));
  }

  get<T>(path: string, params = new HttpParams(),
    headers: HttpHeaders = new HttpHeaders()): Observable<HttpResponse<T> | Observable<never>>{
      return this.http.get<T>(`${environment.api_host}/${path}`,{observe: 'response', params, headers})
        .pipe(catchError(this.formatErrors));
    }
}
