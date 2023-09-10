import { Component, OnInit } from '@angular/core';
import { BuildingModel } from '../../../models/localizations/building.model';
import { AddressModel } from '../../../models/localizations/address.model';
import { LocalizacoesService } from '../../../services/api/localizacoes.service';
import { LocalizationModel } from '../../../models/localizations/localization.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-localizacoes-novo',
  templateUrl: './localizacoes-novo.component.html',
  styleUrls: ['./localizacoes-novo.component.scss']
})
export class LocalizacoesNovoComponent implements OnInit {

  public newAddress: AddressModel = new AddressModel(0, '', '', null, null);
  public newBuilding: BuildingModel = new BuildingModel(0, '', null);
  
  public selectedAddress: AddressModel = new AddressModel(0, '', '', null, null);
  public selectedBuilding: BuildingModel = new BuildingModel(0, '', null);
  
  public newLocalization: LocalizationModel = new LocalizationModel(0, '',  '', this.selectedBuilding);
  
  public buildings: BuildingModel[] = []
  public addresses: AddressModel[] = []

  public isLoading: boolean = false;
  public isNewAddress: boolean = false;
  public isNewBuilding: boolean = false;

  constructor(
    private localizacoesService: LocalizacoesService,
    private router: Router 
    ){

  }

  public save(): void {
    this.isLoading = true;
    this.newLocalization.building = this.selectedBuilding;
    this.localizacoesService.save(this.newLocalization).subscribe(
      res => {
        this.isLoading = false;
        this.router.navigate(["/localizacoes"])
      },
      error => {
        console.log('TODO: show error in popup');
        console.log(error);
        this.isLoading = false;
      }
    )
  }

  public selectBuilding(building: BuildingModel): void {
    if (building.id == 0){
      this.selectedBuilding = this.newBuilding;
      this.isNewBuilding = true;
    }
    else {
      this.selectedBuilding = building;
      this.isNewBuilding = false;
    }
  }

  public selectAddress(address: AddressModel): void {
    if (address.id == 0){
      this.isNewAddress = true;
      this.isNewBuilding = true;
    }
    else {
      this.SearchBuilding(address.id);
      this.isNewAddress = false;
    }
  }

  public SearchAddresses(){
    this.isLoading = true;
    this.localizacoesService.getAddresses().subscribe(
      res => {
        this.addresses = [this.newAddress, ...res.data.map(p => new AddressModel(p.id, p.zipCode, p.number, p.complement, p.observation))];
        this.isLoading = false;
      },
      error => {
        console.log('TODO: show error in popup');
        console.log(error);
      }
    )
  }

  public SearchBuilding(addressId: number) {
    this.isLoading = true;
    this.localizacoesService.getBuildings(addressId).subscribe(
      res => {
        this.buildings = [this.newBuilding, ...res.data.map(p => new BuildingModel(p.id, p.description, p.address))];
        this.isLoading = false;
      },
      error => {
        console.log('TODO: show error in popup');
        console.log(error);
      }
    )
  }

  ngOnInit(): void {
    this.SearchAddresses();
  }
}
