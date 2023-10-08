import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, Output, EventEmitter } from '@angular/core';
import { BuildingModel } from 'src/app/models/localizations/building.model';

@Component({
  selector: 'app-novo-predio',
  templateUrl: './novo-predio.component.html',
  styleUrls: ['./novo-predio.component.scss']
})
export class NovoPredioComponent {
  @Output() newBuilding: EventEmitter<BuildingModel> = new EventEmitter<BuildingModel>();

  public formBuilding: FormGroup = new FormGroup({
    description: new FormControl('', [Validators.required, Validators.minLength(3)])
  })

  public onSubmit(): void {
    let building: BuildingModel = new BuildingModel(0, this.formBuilding.value.description, null);

    this.newBuilding.emit(building);
  }
}
