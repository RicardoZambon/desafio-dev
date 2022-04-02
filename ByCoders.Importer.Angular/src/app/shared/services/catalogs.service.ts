import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, shareReplay } from 'rxjs';

import { environment } from 'src/environments/environment';
import { CatalogItem } from './../models/catalog-item';

@Injectable({
  providedIn: 'root'
})
export class CatalogsService {
  private baseUrl = `${environment.apiUrl}/Catalogs`;

  constructor(private http: HttpClient) { }

  transactionTypes() : Observable<CatalogItem[]> {
    return this.http.get<CatalogItem[]>(`${this.baseUrl}/TransactionTypes`)
      .pipe(
        shareReplay(),
        catchError((error: HttpErrorResponse) => {
          switch(error.status) {
            default:
              throw 'InternalServerError';
            }
          }
        )
      );
  }
}
