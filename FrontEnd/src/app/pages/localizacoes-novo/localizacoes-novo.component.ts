import { Component, EventEmitter, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BuildingModel } from '../../models/localizations/building.model';
import { AddressModel } from '../../models/localizations/address.model';
import { LocalizacoesService } from '../../services/api/localizacoes.service';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormControl, FormGroup, RequiredValidator, ValidatorFn, Validators } from '@angular/forms';
import { __values } from 'tslib';
import { MessageDisplayService } from 'src/app/services/message-display.service';

@Component({
  selector: 'app-localizacoes-novo',
  templateUrl: './localizacoes-novo.component.html',
  styleUrls: ['./localizacoes-novo.component.scss']
})
export class LocalizacoesNovoComponent implements OnInit, OnChanges {
  public isLoading: boolean = false;

  public newAddress: AddressModel = new AddressModel(-1, '', '');
  public newBuilding: BuildingModel = new BuildingModel(-1, '');

  public buildings: BuildingModel[] = []
  public addresses: AddressModel[] = []

  public isNewAddressEditView: boolean = false;
  public isNewBuildingEditView: boolean = false;

  public formLocation: FormGroup = new FormGroup({
    address: new FormControl({ value: null, disabled: true }, [this.validateProperty('id', [Validators.required, Validators.min(0)])]),
    building: new FormControl({ value: null, disabled: true }, [this.validateProperty('id', [Validators.required, Validators.min(0)])]),
    level: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required])
  });

  constructor(
    private localizacoesService: LocalizacoesService,
    private router: Router,
    private messageService: MessageDisplayService
  ) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.disableOrEnableControls();
  }

  ngOnInit(): void {
    this.SearchAddresses();
  }

  public disableOrEnableControls(): void {
    if (this.isNewAddressEditView || this.isLoading) {
      this.formLocation.controls['building'].disable();
    } else {
      this.formLocation.controls['building'].enable();
    }

    if (this.isLoading) {
      this.formLocation.controls['address'].disable();
    } else {
      this.formLocation.controls['address'].enable();
    }
  }

  public createAddress(newAddress: AddressModel): void {
    this.newAddress = newAddress;
    this.isNewBuildingEditView = true;
    this.formLocation.patchValue({
      address: newAddress
    });
  }

  public createBuilding(newBuilding: BuildingModel): void {
    this.newBuilding = newBuilding;
    this.formLocation.patchValue({
      building: newBuilding
    });
  }

  public changeAddress(address: AddressModel): void {
    if (address.id === -1) {
      this.isNewAddressEditView = true;
    } else if (address.id === 0) {
      this.isNewAddressEditView = false;
    } else {
      this.isNewAddressEditView = false;
      this.SearchBuilding(address.id);
    }
  }

  public changeBuilding(building: BuildingModel): void {
    if (building.id === -1) {
      this.isNewBuildingEditView = true;
    } else {
      this.isNewBuildingEditView = false;
    }
  }

  public save(): void {
    this.isLoading = true;
    const building = this.formLocation.value.building as BuildingModel;
    if (building.id === 0) {
      building.address = this.formLocation.value.address as AddressModel;
    }

    const location = new LocalizationModel(
      0,
      this.formLocation.value.description as string,
      this.formLocation.value.level as string,
      building
    );

    this.localizacoesService.save(location).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.messageService.showSuccess('Localização salva com sucesso!')
          this.router.navigate(["/localizacoes"]);
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;

      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }


  public SearchAddresses() {
    this.isLoading = true;
    this.disableOrEnableControls();
    this.localizacoesService.getAddresses().subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.addresses = res.data.map(p => new AddressModel(p.id, p.zipCode, p.number, p.complement, p.observation));
          this.formLocation.controls['address'].enable();
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar endereços')
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno ao buscar endereços, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
        this.disableOrEnableControls();
      }
    });
  }

  public SearchBuilding(addressId: number) {
    this.isLoading = true;
    this.disableOrEnableControls();
    this.localizacoesService.getBuildings(addressId).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.buildings = res.data.map(p => new BuildingModel(p.id, p.description, p.address));
        } else {
          this.messageService.showError(res.error, 'Erro ao buscar prédios');
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno ao buscar prédios, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
        this.disableOrEnableControls();
      }
    })
  }


  private validateProperty(property: string, validators: ValidatorFn[]): ValidatorFn {
    return (control: AbstractControl): { [key: string]: any } | null => {
      // get the value and assign it to a new form control
      const propertyVal = control.value && control.value[property];
      const newFc = new FormControl(propertyVal);
      // run the validators on the new control and keep the ones that fail
      const failedValidators = validators.map(v => v(newFc)).filter(v => !!v);
      // if any fail, return the list of failures, else valid
      return failedValidators.length ? { invalidProperty: failedValidators } : null;
    };
  }
}
