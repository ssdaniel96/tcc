import { Component, OnInit } from '@angular/core';
import { EventHistoryModel } from 'src/app/models/events/event-history.model';
import { EventHistoryParametersModel } from 'src/app/models/events/parameters/event-history-parameters.model';
import { Vector } from 'src/app/models/events/vector';
import { EventosService } from 'src/app/services/api/eventos.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.scss'],
})
export class HistoricoComponent implements OnInit {
  public events: EventHistoryModel[] = new Array<EventHistoryModel>();

  public isLoading: boolean = false;

  constructor(private eventService: EventosService) {}

  ngOnInit(): void {
    this.search(new EventHistoryParametersModel());
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

  public search(filters: EventHistoryParametersModel): void {
    this.isLoading = true;
    this.eventService
      .get(filters)
      .subscribe({
        next: (res) => {
          this.events = res.data.data.map(
            (item) =>
              new EventHistoryModel(
                item.id,
                item.equipmentDescription,
                item.equipmentRfTag,
                item.sensorId,
                item.sensorDescription,
                item.locationDescription,
                item.locationLevel,
                item.locationBuilding,
                item.locationZipCode,
                item.locationNumber,
                item.eventDateTime,
                item.eventVector
              )
          );
        },
        error: (error) => {
          console.log('fix error');
          console.log(error);
        },
      })
      .add(() => {
        this.isLoading = false;
      });
  }
}
