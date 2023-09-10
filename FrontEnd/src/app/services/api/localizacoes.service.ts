import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { Response } from '../../models/shared/response.model';
import { PageResponse } from '../../models/shared/pageResponse.model'


@Injectable({
  providedIn: 'root'
})
export class LocalizacoesService {

  constructor(public httpClient: HttpClient) { }

  public get(): Observable<Response<PageResponse<LocalizationModel>>>{
    return this.httpClient.get<Response<PageResponse<LocalizationModel>>>(`${environment.api_url}/locations`);
  }
}
