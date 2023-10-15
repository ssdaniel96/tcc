import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EquipamentosComponent } from './pages/equipamentos/equipamentos.component';
import { HistoricoComponent } from './pages/historico/historico.component';
import { LocalizacoesComponent } from './pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from './pages/simulacao/simulacao.component';
import { LocalizacoesNovoComponent } from './pages/localizacoes-novo/localizacoes-novo.component';

//TODO: fix routing
const routes: Routes = [
  {path: 'equipamentos', component: EquipamentosComponent },
  {path: 'historico', component: HistoricoComponent },
  // {
  //   path: 'localizacoes', component: LocalizacoesComponent,
  //   children: [
  //     { path: 'novo', component: LocalizacoesNovoComponent }
  //   ]
  // },
  {path: 'localizacoes', component: LocalizacoesComponent },
  {path: 'localizacoes/novo', component: LocalizacoesNovoComponent },
  {path: 'simulacao', component: SimulacaoComponent },
  {path: '', redirectTo: '/equipamentos', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
