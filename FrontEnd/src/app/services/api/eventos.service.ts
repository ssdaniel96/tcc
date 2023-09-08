import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventosService {

  private baseUrl: string = environment.api_url;

  constructor(private httpClient: HttpClient) { }

  // public get(): Observable<any>{
  //   const params = {};

  //   return this.httpClient.get(`${this.baseUrl}/events`, new HttpParams(params));
  // }
}
