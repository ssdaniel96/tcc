import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricoComponent } from '../pages/historico/historico.component';
import { EventosComponent } from '../pages/eventos/eventos.component';
import { EquipamentosComponent } from '../pages/equipamentos/equipamentos.component';
import { LocalizacoesComponent } from '../pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from '../pages/simulacao/simulacao.component';



@NgModule({
  declarations: [
    HistoricoComponent,
    EventosComponent,
    EquipamentosComponent,
    LocalizacoesComponent,
    SimulacaoComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PagesModule { }
