import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddressModel } from 'src/app/models/localizations/address.model';

@Component({
  selector: 'app-novo-endereco',
  templateUrl: './novo-endereco.component.html',
  styleUrls: ['./novo-endereco.component.scss']
})
export class NovoEnderecoComponent {

  public newAddress: AddressModel = new AddressModel(0, '', '');

  @Output() newAddressSelected: EventEmitter<AddressModel> = new EventEmitter<AddressModel>();
  @Output() cancelled: EventEmitter<Boolean> = new EventEmitter<Boolean>(false);

  public newAddressForm: FormGroup = new FormGroup({
    newAddressZipCode: new FormControl(this.newAddress.zipCode, [Validators.required, Validators.maxLength(8), Validators.minLength(8)]),
    newAddressNumber: new FormControl(this.newAddress.number,[Validators.required, Validators.minLength(1)]),
    newAddressComplement: new FormControl(this.newAddress.complement),
    newAddressObservation: new FormControl(this.newAddress.observation)
  })

  public onSubmit(): void {
    this.newAddress = new AddressModel
    (0,
      this.newAddressForm.value.newAddressZipCode,
      this.newAddressForm.value.newAddressNumber,
      this.newAddressForm.value.newAddressComplement,
      this.newAddressForm.value.newAddressObservation);

    this.newAddressSelected.emit(this.newAddress);
  }

  public cancel(): void {
    this.cancelled.emit(true);
  }
}
