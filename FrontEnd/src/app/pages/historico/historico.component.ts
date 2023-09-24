import { Component, OnInit } from '@angular/core';
import { EventHistoryModel } from 'src/app/models/events/event-history.model';
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
    this.search();
  }

  public search(filter: string = ''): void {
    this.isLoading = true;
    this.eventService.get(filter).subscribe({
      next: res => {
        this.events = res.data.map(item => new EventHistoryModel(
          item.equipmentDescription,
          item.equipmentRfTag,
          item.locationDescription,
          item.locationBuilding,
          item.locationZipCode,
          item.locationNumber,
          item.eventDateTime,
          item.eventVector));
      },
      error: error => {
        console.log('fix error');
        console.log(error);
      }
    })
    .add(() => {
      this.isLoading = false;
    })
  }

}
