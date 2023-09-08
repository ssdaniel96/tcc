import { LocalizationModel } from 'src/app/models/localizations/localization.model';
import { LocalizacoesService } from './../../services/api/localizacoes.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-localizacoes',
  templateUrl: './localizacoes.component.html',
  styleUrls: ['./localizacoes.component.scss']
})
export class LocalizacoesComponent implements OnInit {

  public localizations: LocalizationModel[] = [];
  public test: LocalizationModel = new LocalizationModel(1, 't', 1);

  constructor(private localizacoesService: LocalizacoesService){

  }

  ngOnInit(): void {
    this.localizacoesService.get().subscribe(
      res => {
        this.localizations = res;
      },
      error => {
        console.log('an error occured' + error)
      }
    );
  }
}
