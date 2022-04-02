import { IQueryParameters } from './../interfaces/i-query-parameters';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';

import { environment } from 'src/environments/environment';
import { Transactions } from '../models/transactions';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  private baseUrl = `${environment.apiUrl}/Transactions`;

  constructor(private http: HttpClient) { }

  list(params: IQueryParameters) : Observable<Transactions[]> {
    return this.http.post<Transactions[]>(`${this.baseUrl}/List`, params)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          switch(error.status) {
            case 400:
              throw 'InvalidParameters';
            default:
              throw 'InternalServerError';
            }
          }
        )
      );
  }
}
