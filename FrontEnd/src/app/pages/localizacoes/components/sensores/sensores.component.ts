import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
  numberAttribute,
} from '@angular/core';
import { LocalizationModel } from 'src/app/models/localizations/localization.model';
import { InsertSensorModel } from 'src/app/models/sensors/insert-sensor.model.';
import { SensorModel } from 'src/app/models/sensors/sensor.model';
import { PageRequest } from 'src/app/models/shared/pageRequest.model';
import { LocalizacoesService } from 'src/app/services/api/localizacoes.service';
import { MessageDisplayService } from 'src/app/services/message-display.service';

@Component({
  selector: 'app-sensores',
  templateUrl: './sensores.component.html',
  styleUrls: ['./sensores.component.scss'],
})
export class SensoresComponent implements OnInit, OnChanges {
  @Input({ alias: 'location-id', transform: numberAttribute })
  locationId: number = 0;
  @Input() location: LocalizationModel = new LocalizationModel(0, '', '', null);

  public newSensor: InsertSensorModel = this.getNewSensorDefault();
  public sensors: SensorModel[] = new Array<SensorModel>();

  public isLoading: boolean = false;
  public isNewSensor: boolean = false;

  constructor(
    private localizationService: LocalizacoesService,
    private messageService: MessageDisplayService) { }

  public setToEditTable(): void {
    this.isNewSensor = true;
  }

  public setToViewTable(): void {
    this.isNewSensor = false;
  }

  private setNewSensorToDefault(): void {
    this.newSensor = this.getNewSensorDefault();
  }

  private getNewSensorDefault(): InsertSensorModel {
    return new InsertSensorModel(0, '', this.locationId);
  }

  public add(): void {
    this.isLoading = true;
    this.localizationService.addSensor(this.newSensor).subscribe({
      next: (response) => {
        if (response.isSuccessfully) {
          this.getSensors(this.locationId);
          this.setNewSensorToDefault();
          this.setToViewTable();
          this.messageService.showSuccess('Sensor adicionado com sucesso à localização');
        } else {
          this.messageService.showError(response.error);
        }
      },
      error: (error) => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }

  public remove(sensorId: number): void {
    this.isLoading = true;
    this.localizationService.deleteSensor(sensorId).subscribe({
      next: (res) => {
        if (res.isSuccessfully) {
          this.sensors = this.sensors.filter((p) => p.id != sensorId);
          this.messageService.showSuccess('Sensor removido com sucesso da localização');
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: (error) => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      }
    });
  }

  private getSensors(locationId: number): void {
    this.isLoading = true;
    this.localizationService.getSensors(locationId, new PageRequest(1, 100)).subscribe({
      next: (response) => {
        if (response.isSuccessfully) {
          this.sensors = response.data.data;
        } else {
          this.messageService.showError(response.error);
        }
      },
      error: (error) => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.isLoading = false;
      },
      complete: () => {
        this.isLoading = false;
      }
  });
  }

  ngOnInit(): void {
    this.getSensors(this.locationId);
    this.setNewSensorToDefault();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.getSensors(this.locationId);
    this.setNewSensorToDefault();
  }
}
