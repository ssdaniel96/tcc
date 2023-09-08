import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EquipmentModel } from 'src/app/models/equipments/equipment.model';
import { InsertEquipmentModel } from 'src/app/models/equipments/insert-equipment.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EquipamentosService {

  private baseUrl: string = `${environment.api_url}/equipments`;

  constructor(private httpClient: HttpClient) { }

  public get(): Observable<EquipmentModel[]>{
    return this.httpClient.get<EquipmentModel[]>(`${this.baseUrl}`);
  }

  public getById(id: number): Observable<EquipmentModel>{
    return this.httpClient.get<EquipmentModel>(`${this.baseUrl}/${id}`);
  }

  public deleteById(id: number): Observable<any>{
    return this.httpClient.delete(`${this.baseUrl}/${id}`);
  }

  public insert(equipment: InsertEquipmentModel): Observable<EquipmentModel>{
    return this.httpClient.post<EquipmentModel>(`${this.baseUrl}`, equipment);
  }
}
