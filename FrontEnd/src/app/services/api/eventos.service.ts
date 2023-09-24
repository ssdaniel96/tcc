import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { NewEventModel } from 'src/app/models/events/new-event.model';
import { Observable } from 'rxjs';
import { SimpleResponse } from 'src/app/models/shared/response.model';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private baseUrl: string = environment.api_url;

  constructor(private httpClient: HttpClient) { }

  public save(event: NewEventModel): Observable<SimpleResponse>{
    return this.httpClient.post<SimpleResponse>(`${this.baseUrl}`, event);
  }
}
