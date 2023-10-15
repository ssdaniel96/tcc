import { MessageDisplayService } from 'src/app/services/message-display.service';
import { LocalizationModel } from '../../models/localizations/localization.model';
import { PageResponse } from '../../models/shared/pageResponse.model';
import { LocalizacoesService } from './../../services/api/localizacoes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-localizacoes',
  templateUrl: './localizacoes.component.html',
  styleUrls: ['./localizacoes.component.scss']
})
export class LocalizacoesComponent implements OnInit {

  public localizationsPage: PageResponse<LocalizationModel> = new PageResponse<LocalizationModel>(0, 0, 0, []);

  public locationDetailsSelected = new LocalizationModel(0, '', '', null);

  public loading: boolean = false;

  constructor(
    private localizacoesService: LocalizacoesService,
    private messageService: MessageDisplayService) {

  }

  ngOnInit(): void {
    this.search();
  }

  public search(): void {
    this.loading = true;
    this.localizacoesService.get().subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.localizationsPage = res.data;
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    });
  }

  public remove(id: number): void {
    this.loading = true;
    this.localizacoesService.removeById(id).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.localizationsPage.data = this.localizationsPage.data.filter(p => p.id != id);
          this.messageService.showSuccess('A localização foi removida com sucesso');
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }

  public setDetails(location: LocalizationModel): void {
    this.locationDetailsSelected = location;
  }

}
