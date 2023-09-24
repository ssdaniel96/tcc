import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { NewEventModel } from 'src/app/models/events/new-event.model';
import { Observable } from 'rxjs';
import { Response, SimpleResponse } from 'src/app/models/shared/response.model';
import { EventHistoryModel } from 'src/app/models/events/event-history.model';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private baseUrl: string = `${environment.api_url}/events`;

  constructor(private httpClient: HttpClient) { }

  public save(event: NewEventModel): Observable<SimpleResponse>{
    return this.httpClient.post<SimpleResponse>(`${this.baseUrl}`, event);
  }

  public get(filter: string = ''): Observable<Response<EventHistoryModel[]>>{
    let queryParams: string = '';
    if (filter){
      queryParams += `?filter=${filter}`;
    }

    return this.httpClient.get<Response<EventHistoryModel[]>>(`${this.baseUrl}${queryParams}`)
  }
}
