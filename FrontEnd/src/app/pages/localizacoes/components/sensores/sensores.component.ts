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
import { LocalizacoesService } from 'src/app/services/api/localizacoes.service';

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

  constructor(private localizationService: LocalizacoesService) {}

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
    this.localizationService.addSensor(this.newSensor).subscribe(
      (response) => {
        this.getSensors(this.locationId);
        this.setNewSensorToDefault();
        this.setToViewTable();
        this.isLoading = false;
      },
      (error) => {
        console.log('TODO: errors');
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  public delete(sensorId: number): void {
    this.isLoading = true;
    this.localizationService.deleteSensor(sensorId).subscribe(
      (res) => {
        this.sensors = this.sensors.filter((p) => p.id != sensorId);
        this.isLoading = false;
      },
      (error) => {
        console.log('TODO: errors');
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  private getSensors(locationId: number): void {
    this.isLoading = true;
    this.localizationService.getSensors(locationId).subscribe(
      (response) => {
        this.sensors = response.data;
        this.isLoading = false;
      },
      (error) => {
        console.log('TODO: errors');
        console.log(error);
        this.isLoading = false;
      }
    );
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
