import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricoComponent } from '../pages/historico/historico.component';
import { EventosComponent } from '../pages/eventos/eventos.component';
import { EquipamentosComponent } from '../pages/equipamentos/equipamentos.component';
import { LocalizacoesComponent } from '../pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from '../pages/simulacao/simulacao.component';
import { BrowserModule } from '@angular/platform-browser';
import { AppModule } from '../app.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    HistoricoComponent,
    EventosComponent,
    EquipamentosComponent,
    LocalizacoesComponent,
    SimulacaoComponent
  ],
  imports: [
    CommonModule,
    FormsModule
    // BrowserModule
  ]
})
export class PagesModule { }
