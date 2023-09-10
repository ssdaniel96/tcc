import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { Response, SimpleResponse } from '../../models/shared/response.model';
import { PageResponse } from '../../models/shared/pageResponse.model'
import { AddressModel } from '../../models/localizations/address.model';
import { BuildingModel } from '../../models/localizations/building.model';
import { SensorModel } from '../../models/sensors/sensor.model';
import { InsertSensorModel } from '../../models/sensors/insert-sensor.model.';


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

  public getAddresses(): Observable<Response<AddressModel[]>>{
    return this.httpClient.get<Response<AddressModel[]>>(`${this.baseRoute}/addresses`)
  }

  public getBuildings(addressId: number): Observable<Response<BuildingModel[]>>{
    //TODO: fix params
    // const httpParams = new HttpParams();
    // httpParams.append('addressId', addressId);

    return this.httpClient.get<Response<BuildingModel[]>>(`${this.baseRoute}/buildings?addressId=${addressId}`)
  }

  public save(newLocalization: LocalizationModel): Observable<Response<LocalizationModel>>{
    return this.httpClient.post<Response<LocalizationModel>>(`${this.baseRoute}`, newLocalization);
  }

  public getSensors(locationId: number): Observable<Response<SensorModel[]>>{
    return this.httpClient.get<Response<SensorModel[]>>(`${this.baseRoute}/sensors/${locationId}`);
  }

  public deleteSensor(sensorId: number): Observable<SimpleResponse>{
    return this.httpClient.delete<SimpleResponse>(`${this.baseRoute}/sensors/${sensorId}`);
  }

  public addSensor(insertSensor: InsertSensorModel): Observable<Response<SensorModel>>{
    return this.httpClient.post<Response<SensorModel>>(`${this.baseRoute}`, insertSensor)
  }
}
