import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EquipamentosComponent } from './pages/equipamentos/equipamentos.component';
import { EventosComponent } from './pages/eventos/eventos.component';
import { HistoricoComponent } from './pages/historico/historico.component';
import { LocalizacoesComponent } from './pages/localizacoes/localizacoes.component';
import { SimulacaoComponent } from './pages/simulacao/simulacao.component';

const routes: Routes = [
  {path: 'equipamentos', component: EquipamentosComponent },
  {path: 'eventos', component: EventosComponent },
  {path: 'historico', component: HistoricoComponent },
  {path: 'localizacoes', component: LocalizacoesComponent },
  {path: 'simulacao', component: SimulacaoComponent },
  {path: '', redirectTo: '/equipamentos', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
