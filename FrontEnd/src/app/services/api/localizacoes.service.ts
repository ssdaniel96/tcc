import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, ObservedValueOf } from 'rxjs';
import { LocalizationModel } from 'src/app/models/localizations/localization.model';


@Injectable({
  providedIn: 'root'
})
export class LocalizacoesService {

  constructor(public httpClient: HttpClient) { }

  public get(): Observable<LocalizationModel[]>{
    const test = this.httpClient.get<LocalizationModel[]>(`${environment.api_url}/locations`);
    console.log(test);
    return test;
  }
}
