import { Injectable } from "@angular/core";
import { AppUserService } from "src/app/@core/services/admin/app-user.service";
import { ApiService } from "src/app/@core/services/api.service";
import { Observable } from 'rxjs';
import { HttpResponse } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { catchError, map } from "rxjs/operators";

@Injectable()

export class ApiAppUser extends AppUserService{

  constructor(
    private apiService: ApiService
  ) {
    super();

  }

  GetAllUser(): Observable<HttpResponse<Array<any>> | Observable<never>>{
    return this.apiService.post<Array<any>>(environment.get_all_user).pipe(
      map(x => {
        return x;
      }),
      catchError(error => {
        if (error instanceof (Error)) {
          throw new Error(error.message);
        }else{
          console.log('error posting to get all users');
          throw new Error(error);
        }
      })
    );
  }
}
