import { HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()

export abstract class AppUserService{
  abstract GetAllUser(): Observable<HttpResponse<Array<any>> | Observable<never>>;
}
