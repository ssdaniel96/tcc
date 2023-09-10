import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricoComponent } from '../pages/historico/historico.component';
import { EquipamentosComponent } from '../pages/equipamentos/equipamentos.component';
import { LocalizacoesComponent } from '../pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from '../pages/simulacao/simulacao.component';
import { FormsModule } from '@angular/forms';
import { LocalizacoesNovoComponent } from './localizacoes/localizacoes-novo/localizacoes-novo.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    HistoricoComponent,
    EquipamentosComponent,
    LocalizacoesComponent,
    SimulacaoComponent,
    LocalizacoesNovoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ]
})
export class PagesModule { }
