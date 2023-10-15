import { PageRequest } from './../../models/shared/pageRequest.model';
import { EventHistoryParametersModel } from './../../models/events/parameters/event-history-parameters.model';
import { Component, OnInit } from '@angular/core';
import { EventHistoryModel } from 'src/app/models/events/event-history.model';
import { Vector } from 'src/app/models/events/vector';
import { PageResponse } from 'src/app/models/shared/pageResponse.model';
import { EventosService } from 'src/app/services/api/eventos.service';
import { PaginatorState } from 'primeng/paginator';
import { MessageDisplayService } from 'src/app/services/message-display.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.scss'],
})
export class HistoricoComponent implements OnInit {
  public pageRequest: PageRequest = new PageRequest(1, 5);

  public events: PageResponse<EventHistoryModel> = new PageResponse<EventHistoryModel>(this.pageRequest.pageNumber, this.pageRequest.pageSize, 0, []);
  public parameters: EventHistoryParametersModel = new EventHistoryParametersModel();

  public isLoading: boolean = false;

  constructor(
    private eventService: EventosService,
    private messageService: MessageDisplayService) {}

  ngOnInit(): void {
    this.search();
  }

  public onPageChange(item: PaginatorState): void {
    this.pageRequest.pageNumber = (item.first! / item.rows!)+1;
    this.pageRequest.pageSize = item.rows!;
    this.searchByEvent(this.parameters);
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

  public search(): void {
    this.isLoading = true;
    this.eventService
      .get(this.parameters)
      .subscribe({
        next: (res) => {
          if (res.isSuccessfully) {
            this.events = res.data;
          } else {
            this.messageService.showError(res.error);
          }
        },
        error: (error) => {
          this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
          console.log(error);
          this.isLoading = false;
        },
      })
      .add(() => {
        this.isLoading = false;
      });
  }

  public searchByEvent(filters: EventHistoryParametersModel): void {
    filters.pageRequest = this.pageRequest;
    this.parameters = filters;
    this.search();
  }
}
