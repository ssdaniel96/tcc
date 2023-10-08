import { EquipmentModel } from 'src/app/models/equipments/equipment.model';
import { AddressModel } from 'src/app/models/localizations/address.model';
import { EventHistoryParametersModel } from './../../../../models/events/parameters/event-history-parameters.model';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Vector } from 'src/app/models/events/vector';
import { BuildingModel } from 'src/app/models/localizations/building.model';
import { LocalizationModel } from 'src/app/models/localizations/localization.model';
import { SensorModel } from 'src/app/models/sensors/sensor.model';
import { LocalizacoesService } from 'src/app/services/api/localizacoes.service';
import { EquipamentosService } from 'src/app/services/api/equipamentos.service';
import { EventosService } from 'src/app/services/api/eventos.service';
import { PageRequest } from 'src/app/models/shared/pageRequest.model';

@Component({
  selector: 'app-historico-header',
  templateUrl: './historico-header.component.html',
  styleUrls: ['./historico-header.component.scss']
})
export class HistoricoHeaderComponent implements OnInit {
  public headerParameters: EventHistoryParametersModel = new EventHistoryParametersModel();

  public equipments: EquipmentModel[] = new Array<EquipmentModel>();
  public vectors: Vector[] = [Vector.IN, Vector.OUT];
  public addresses: AddressModel[] = new Array<AddressModel>();
  public buildings: BuildingModel[] = new Array<BuildingModel>();
  public locations: LocalizationModel[] = new Array<LocalizationModel>();
  public sensors: SensorModel[] = new Array<SensorModel>();

  @Output() searchParamaters: EventEmitter<EventHistoryParametersModel> = new EventEmitter<EventHistoryParametersModel>();

  public isLoading: boolean = false;

  constructor(
    private locationService: LocalizacoesService,
    private equipmentService: EquipamentosService,
    private eventService: EventosService
  ) {

  }
  ngOnInit(): void {
    this.searchEquipments();
    this.searchSensors();
  }

  public searchEquipments(): void {
    this.isLoading = true;
    this.equipmentService.get().subscribe({
      next: response => {
        this.equipments = response.data.map(item => new EquipmentModel(item.id, item.rfTag, item.description));
      },
      error: error => {
        console.log('TODO error fix');
        console.log(error);
      },
      complete: () => {
        this.isLoading = false;
      }
    })
  }


  private getLocationsFromSensors(sensors: SensorModel[]): LocalizationModel[] {
    const locations = sensors.map(p => p.location);
    const uniqueIds = [... new Set(locations.map(item => item!.id))];

    const uniqueArray: LocalizationModel[] = new Array<LocalizationModel>();
    uniqueIds.forEach(id => {
      uniqueArray.push(locations.find(p => p!.id == id)!)
    });
    return uniqueArray;
  }

  private getBuildingsFromLocations(locations: LocalizationModel[]): BuildingModel[] {
    const buildings = locations.map(item => item.building)!;
    const uniqueIds = [... new Set(buildings.map(item => item!.id))];

    const uniqueArray: BuildingModel[] = new Array<BuildingModel>();
    uniqueIds.forEach(id => {
      uniqueArray.push(buildings.find(p => p!.id == id)!)
    });

    return uniqueArray;
  }

  private getAddressesFromBuildings(buildings: BuildingModel[]): AddressModel[] {
    const addresses = buildings.map(item => item.address)!;
    const uniqueIds = [... new Set(addresses.map(item => item!.id))];

    const uniqueArray: AddressModel[] = new Array<AddressModel>();
    uniqueIds.forEach(id => {
      uniqueArray.push(addresses.find(p => p!.id == id)!)
    });

    return uniqueArray;
  }

  public searchSensors(): void {
    this.isLoading = true;
    //TODO: pagination
    this.locationService.getSensors(0, new PageRequest(1, 100)).subscribe({
      next: response => {
        this.sensors = response.data.data.map(item => new SensorModel(item.id, item.description, item.location));
        this.locations = this.getLocationsFromSensors(this.sensors).map(p => new LocalizationModel(p.id, p.description, p.level, p.building));
        this.buildings = this.getBuildingsFromLocations(this.locations).map(p => new BuildingModel(p.id, p.description, p.address));
        this.addresses = this.getAddressesFromBuildings(this.buildings).map(p => new AddressModel(p.id, p.zipCode, p.number, p.complement, p.observation));
      },
      error: error => {
        console.log('TODO error fix');
        console.log(error);
      },
      complete: () => {
        this.isLoading = false;
      }
    })
  }

  public onSubmit(): void{
    this.searchParamaters.emit(this.headerParameters);
  }

  public getVectorDescription(vector: Vector): string {
    if (vector === Vector.IN) {
      return 'Entrada';
    } else if (vector === Vector.OUT) {
      return 'Saída';
    } else {
      return 'Não identificado';
    }
  }
}
