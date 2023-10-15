import { Component, OnInit } from '@angular/core';
import { EquipmentModel } from 'src/app/models/equipments/equipment.model';
import { NewEventModel } from 'src/app/models/events/new-event.model';
import { Vector } from 'src/app/models/events/vector';
import { AddressModel } from 'src/app/models/localizations/address.model';
import { BuildingModel } from 'src/app/models/localizations/building.model';
import { LocalizationModel } from 'src/app/models/localizations/localization.model';
import { SensorModel } from 'src/app/models/sensors/sensor.model';
import { PageRequest } from 'src/app/models/shared/pageRequest.model';
import { EquipamentosService } from 'src/app/services/api/equipamentos.service';
import { EventosService } from 'src/app/services/api/eventos.service';
import { LocalizacoesService } from 'src/app/services/api/localizacoes.service';
import { MessageDisplayService } from 'src/app/services/message-display.service';

@Component({
  selector: 'app-simulacao',
  templateUrl: './simulacao.component.html',
  styleUrls: ['./simulacao.component.scss']
})
export class SimulacaoComponent implements OnInit {
  public locations: LocalizationModel[] = new Array<LocalizationModel>();
  public buildings: BuildingModel[] = new Array<BuildingModel>();
  public addresses: AddressModel[] = new Array<AddressModel>();
  public equipments: EquipmentModel[] = new Array<EquipmentModel>();
  public sensors: SensorModel[] = new Array<SensorModel>();
  public vectors: Vector[] = [Vector.IN, Vector.OUT];

  public selectedAddress: AddressModel = new AddressModel(0, '', '', null, null);
  public selectedBuilding: BuildingModel = new BuildingModel(0, '', null);
  public selectedLocation: LocalizationModel = new LocalizationModel(0, '', '', null);
  public selectedSensor: SensorModel = new SensorModel(0, '', null);
  public selectedVector: Vector = 0 as Vector;
  public selectedEquipment: EquipmentModel = new EquipmentModel();

  public addressWasSelected: boolean = false;
  public buildingWasSelected: boolean = false;
  public locationWasSelected: boolean = false;
  public isLoading: boolean = false;


  constructor(
    private locationService: LocalizacoesService,
    private equipmentService: EquipamentosService,
    private eventService: EventosService,
    private messageService: MessageDisplayService
  ) {

  }


  private resetBuilding(): void {
    this.selectedBuilding = new BuildingModel(0, '', null);
    this.buildingWasSelected = false;
    this.resetLocation();
  }

  private resetLocation(): void {
    this.selectedLocation = new LocalizationModel(0, '', '', null);
    this.locationWasSelected = false;
    this.resetSensor();
  }

  private resetSensor(): void {
    this.selectedSensor = new SensorModel(0, '', null);
  }

  public save(): void {
    const newEvent = new NewEventModel(this.selectedEquipment.rfTag, this.selectedVector, this.selectedSensor.id);
    this.isLoading = true;
    this.eventService.save(newEvent).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.messageService.showSuccess('Novo evento salvo com sucesso! Consultar tela de histórico para mais detalhes!');
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      });
  }


  public IsValidToSave(): boolean {
    return !!(this.selectedAddress.id
      && this.selectedBuilding.id
      && this.selectedLocation.id
      && this.selectedVector
      && this.selectedEquipment.id);
  }

  public selectAddress(address: AddressModel): void {
    if (address.id) {
      this.searchBuilding();
      this.addressWasSelected = true;
      this.resetBuilding();
    }
    else {
      this.addressWasSelected = false;
    }
  }

  public selectBuilding(building: BuildingModel): void {
    if (building.id) {
      this.searchLocation();
      this.buildingWasSelected = true;
      this.resetLocation();
    }
    else {
      this.buildingWasSelected = false;
    }
  }

  public selectLocation(location: LocalizationModel): void {
    if (location.id) {
      this.searchSensors();
      this.locationWasSelected = true;
      this.resetSensor();
    }
    else {
      this.locationWasSelected = false;
    }
  }

  public searchEquipment(filter: string | null = null): void {
    this.isLoading = true;
    this.equipmentService.get(filter).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.equipments = res.data.map(item => new EquipmentModel(item.id, item.rfTag, item.description));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar equipamentos');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      });
  }

  public searchBuilding(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.getBuildings(this.selectedAddress.id, filter).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.buildings = res.data.map(p => new BuildingModel(p.id, p.description, p.address));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar prédios');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      })
  }

  public searchLocation(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.get(this.selectedBuilding.id, filter).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.locations = res.data.data.map(p => new LocalizationModel(p.id, p.description, p.level, p.building));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar localizações');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      })
  }

  public searchSensors(): void {
    this.isLoading = true;
    this.locationService.getSensors(this.selectedLocation.id, new PageRequest(1, 100)).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.sensors = res.data.data.map(p => new SensorModel(p.id, p.description, p.location));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar sensores');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      })
  }

  public searchAddress(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.getAddresses(filter).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.addresses = res.data.map(p => new AddressModel(p.id, p.zipCode, p.number, p.complement, p.observation));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar endereços');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
      }
    })
      .add(() => {
        this.isLoading = false;
      })
  }

  ngOnInit(): void {
    this.searchAddress();
    this.searchEquipment();
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
