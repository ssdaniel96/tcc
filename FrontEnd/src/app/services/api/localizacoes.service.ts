import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { Response, SimpleResponse } from '../../models/shared/response.model';
import { PageResponse } from '../../models/shared/pageResponse.model'


@Injectable({
  providedIn: 'root'
})
export class LocalizacoesService {

  private baseRoute: string = `${environment.api_url}/locations` ;

  constructor(public httpClient: HttpClient) { }

  public get(): Observable<Response<PageResponse<LocalizationModel>>>{
    return this.httpClient.get<Response<PageResponse<LocalizationModel>>>(this.baseRoute);
  }

  public removeById(id: number): Observable<SimpleResponse>{
    return this.httpClient.delete<SimpleResponse>(`${this.baseRoute}/${id}`)
  }
}
