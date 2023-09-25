import { Component, OnInit } from '@angular/core';
import { EquipmentModel } from 'src/app/models/equipments/equipment.model';
import { NewEventModel } from 'src/app/models/events/new-event.model';
import { Vector } from 'src/app/models/events/vector';
import { AddressModel } from 'src/app/models/localizations/address.model';
import { BuildingModel } from 'src/app/models/localizations/building.model';
import { LocalizationModel } from 'src/app/models/localizations/localization.model';
import { EquipamentosService } from 'src/app/services/api/equipamentos.service';
import { EventosService } from 'src/app/services/api/eventos.service';
import { LocalizacoesService } from 'src/app/services/api/localizacoes.service';

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
  public vectors: Vector[] = [Vector.IN, Vector.OUT];

  public selectedAddress: AddressModel = new AddressModel(0, '', '', null, null);
  public selectedBuilding: BuildingModel = new BuildingModel(0, '', null);
  public selectedLocation: LocalizationModel = new LocalizationModel(0, '', '', null);
  public selectedVector: Vector = 0 as Vector;
  public selectedEquipment: EquipmentModel = new EquipmentModel();

  public addressWasSelected: boolean = false;
  public buildingWasSelected: boolean = false;
  public isLoading: boolean = false;


  constructor(
    private locationService: LocalizacoesService,
    private equipmentService: EquipamentosService,
    private eventService: EventosService
  ) {

  }

  public resetAll(): void {
    this.selectedAddress = new AddressModel(0, '', '', null, null);
    this.selectedBuilding = new BuildingModel(0, '', null);
    this.selectedLocation = new LocalizationModel(0, '', '', null);
    this.selectedVector = 0 as Vector;
    this.selectedEquipment = new EquipmentModel();
    this.addressWasSelected = false;
    this.buildingWasSelected = false;
  }

  public save(): void {
    const newEvent = new NewEventModel(this.selectedEquipment.rfTag, this.selectedVector, this.selectedLocation.id);
    this.isLoading = true;
    this.eventService.save(newEvent).subscribe({
      next: res => {
        console.log(res.isSuccessfully)
        this.resetAll();
      },
      error: error => {
        console.log('TODO: fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading =false;
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
    if (address.id){
      this.searchBuilding();
      this.addressWasSelected = true;
    }
    else {
      this.addressWasSelected = false;
    }
  }

  public selectBuilding(building: BuildingModel): void {
    if (building.id){
      this.searchLocation();
      this.buildingWasSelected = true;
    }
    else {
      this.buildingWasSelected = false;
    }
  }

  public searchEquipment(filter: string | null = null): void {
    this.isLoading = true;
    this.equipmentService.get(filter).subscribe({
      next: res => {
        this.equipments = res.data.map(item => new EquipmentModel(item.id, item.rfTag, item.description));
      },
      error: error => {
        console.log('TODO: fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading =false;
    });
  }

  public searchBuilding(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.getBuildings(this.selectedAddress.id, filter).subscribe({
      next: res => {
        this.buildings = res.data.map(p => new BuildingModel(p.id, p.description, p.address));
      },
      error: error => {
        console.log('TODO: fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading =false;
    })
  }

  public searchLocation(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.get(this.selectedBuilding.id, filter).subscribe({
      next: res => {
        this.locations = res.data.data.map(p => new LocalizationModel(p.id, p.description, p.level, p.building));
      },
      error: error => {
        console.log('TODO: fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading =false;
    })
  }

  public searchAddress(filter: string | null = null): void {
    this.isLoading = true;
    this.locationService.getAddresses(filter).subscribe({
      next: res => {
        this.addresses = res.data.map(p => new AddressModel(p.id, p.zipCode, p.number, p.complement, p.observation));
        this.isLoading = false;
      },
      error: error => {
        console.log('TODO: fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading =false;
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
