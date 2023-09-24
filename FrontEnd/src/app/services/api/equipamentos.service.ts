import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EquipmentModel } from 'src/app/models/equipments/equipment.model';
import { InsertEquipmentModel } from 'src/app/models/equipments/insert-equipment.model';
import { Response, SimpleResponse } from '../../models/shared/response.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EquipamentosService {

  private baseUrl: string = `${environment.api_url}/equipments`;

  constructor(private httpClient: HttpClient) { }

  public get(filter: string | null = null): Observable<Response<EquipmentModel[]>>{
    let queryParams: string | null = null;
    if (!filter){
      queryParams = `?filter=${filter}`;
    }

    return this.httpClient.get<Response<EquipmentModel[]>>(`${this.baseUrl}${queryParams}`);
  }

  public getById(id: number): Observable<Response<EquipmentModel>>{
    return this.httpClient.get<Response<EquipmentModel>>(`${this.baseUrl}/${id}`);
  }

  public deleteById(id: number): Observable<SimpleResponse>{
    return this.httpClient.delete<SimpleResponse>(`${this.baseUrl}/${id}`);
  }

  public insert(equipment: InsertEquipmentModel): Observable<Response<EquipmentModel>>{
    return this.httpClient.post<Response<EquipmentModel>>(`${this.baseUrl}`, equipment);
  }
}
