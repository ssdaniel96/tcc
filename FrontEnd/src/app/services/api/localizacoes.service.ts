import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { Response, SimpleResponse } from '../../models/shared/response.model';
import { PageResponse } from '../../models/shared/pageResponse.model';
import { AddressModel } from '../../models/localizations/address.model';
import { BuildingModel } from '../../models/localizations/building.model';
import { SensorModel } from '../../models/sensors/sensor.model';
import { InsertSensorModel } from '../../models/sensors/insert-sensor.model.';
import { query } from '@angular/animations';

@Injectable({
  providedIn: 'root',
})
export class LocalizacoesService {
  private baseRoute: string = `${environment.api_url}/locations`;

  constructor(public httpClient: HttpClient) {}

  public get(
    buildingId: number = 0,
    filter: string | null = null
  ): Observable<Response<PageResponse<LocalizationModel>>> {
    let queryParams = `?buildingId=${buildingId}`;
    if (filter) {
      queryParams += `&filter=${filter}`;
    }

    return this.httpClient.get<Response<PageResponse<LocalizationModel>>>(
      this.baseRoute + queryParams
    );
  }

  public removeById(id: number): Observable<SimpleResponse> {
    return this.httpClient.delete<SimpleResponse>(`${this.baseRoute}/${id}`);
  }

  public getAddresses(
    filter: string | null = null
  ): Observable<Response<AddressModel[]>> {
    let queryParams = '';
    if (filter) {
      queryParams = `?filter=${filter}`;
    }

    return this.httpClient.get<Response<AddressModel[]>>(
      `${this.baseRoute}/addresses${queryParams}`
    );
  }

  public getBuildings(
    addressId: number,
    filter: string | null = null
  ): Observable<Response<BuildingModel[]>> {
    //TODO: fix params
    // const httpParams = new HttpParams();
    // httpParams.append('addressId', addressId);
    let queryParams = `?addressId=${addressId}`;

    if (filter) {
      queryParams += `&filter=${filter}`;
    }

    return this.httpClient.get<Response<BuildingModel[]>>(
      `${this.baseRoute}/buildings${queryParams}`
    );
  }

  public save(
    newLocalization: LocalizationModel
  ): Observable<Response<LocalizationModel>> {
    return this.httpClient.post<Response<LocalizationModel>>(
      `${this.baseRoute}`,
      newLocalization
    );
  }

  public getSensors(locationId: number): Observable<Response<SensorModel[]>> {
    return this.httpClient.get<Response<SensorModel[]>>(
      `${this.baseRoute}/sensors/${locationId}`
    );
  }

  public deleteSensor(sensorId: number): Observable<SimpleResponse> {
    return this.httpClient.delete<SimpleResponse>(
      `${this.baseRoute}/sensors/${sensorId}`
    );
  }

  public addSensor(
    insertSensor: InsertSensorModel
  ): Observable<Response<SensorModel>> {
    return this.httpClient.post<Response<SensorModel>>(
      `${this.baseRoute}/sensors`,
      insertSensor
    );
  }
}
