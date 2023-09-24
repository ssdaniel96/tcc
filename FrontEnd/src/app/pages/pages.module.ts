import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoricoComponent } from '../pages/historico/historico.component';
import { EquipamentosComponent } from '../pages/equipamentos/equipamentos.component';
import { LocalizacoesComponent } from '../pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from '../pages/simulacao/simulacao.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LocalizacoesNovoComponent } from './localizacoes/localizacoes-novo/localizacoes-novo.component';
import { RouterModule } from '@angular/router';
import { SensoresComponent } from './localizacoes/components/sensores/sensores.component';



@NgModule({
  declarations: [
    HistoricoComponent,
    EquipamentosComponent,
    LocalizacoesComponent,
    SimulacaoComponent,
    LocalizacoesNovoComponent,
    SensoresComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class PagesModule { }
