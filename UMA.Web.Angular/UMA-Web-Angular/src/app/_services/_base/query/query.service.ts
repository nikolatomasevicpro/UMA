import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigurationService } from '../config/configuration.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { NotificationService } from '../notification/notification.service';
import { IRequest } from 'src/app/_models/interfaces/IRequest';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class QueryService {

  constructor(
    private config: ConfigurationService,
    private http: HttpClient,
    private notification: NotificationService
    ) { }

  typedSend<T>(service: string, query: IRequest<T>): Observable<T> {
    const endPoint = this.config.getApiEndpointForService(service);

    if (endPoint) {
      switch (endPoint.type) {
        case 'get':
          return this.http.get<T>(this.config.config.apiUrl + endPoint.endpoint).pipe(
            catchError(this.handleError<T>(endPoint.endpoint, null))
            );
        case 'post':
          return this.http.post<T>(this.config.config.apiUrl + endPoint.endpoint, query, httpOptions).pipe(
            catchError(this.handleError<T>(endPoint.endpoint, null))
            );
        case 'put':
          return this.http.put<T>(this.config.config.apiUrl + endPoint.endpoint, query, httpOptions).pipe(
            catchError(this.handleError<T>(endPoint.endpoint, null))
            );
        case 'delete':
          return this.http.delete<T>(this.config.config.apiUrl + endPoint.endpoint, httpOptions).pipe(
            catchError(this.handleError<T>(endPoint.endpoint, null))
            );
        default:
          break;
      }
    }
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      console.error(error);

      this.notification.error(error.message, `${operation} failed :`);

      return of(result as T);
    };
  }
}
