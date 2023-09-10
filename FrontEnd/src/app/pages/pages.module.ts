import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricoComponent } from '../pages/historico/historico.component';
import { EquipamentosComponent } from '../pages/equipamentos/equipamentos.component';
import { LocalizacoesComponent } from '../pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from '../pages/simulacao/simulacao.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    HistoricoComponent,
    EquipamentosComponent,
    LocalizacoesComponent,
    SimulacaoComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PagesModule { }
