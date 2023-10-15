import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from '../shared/menu/menu.component';
import { RouterModule } from '@angular/router';
import { LoadingBarComponent } from './loading-bar/loading-bar.component';
import { ProgressBarModule } from 'primeng/progressbar';
import { ToastModule } from 'primeng/toast';



@NgModule({
  declarations: [
    MenuComponent,
    LoadingBarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ProgressBarModule,
    ToastModule
  ],
  exports:[
    MenuComponent,
    LoadingBarComponent
  ]
})
export class SharedModule { }

