import { Injectable } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

@Injectable({
  providedIn: 'root'
})

export class MessageDisplayService {

  public currentDuration: number = 5000;

  constructor(private toastService: NgToastService) { }

  public showSuccess(message: string, title: string = 'Sucesso'): void {
    this.toastService.success({detail: title, summary: message, duration: this.currentDuration})
  }

  public showError(message: string, title: string = 'Ocorreu um erro'): void {
    this.toastService.error({detail: title, summary: message, duration: this.currentDuration})
  }

  public showWarning(message: string, title: string = 'Aviso'): void {
    this.toastService.warning({detail: title, summary: message, duration: this.currentDuration})
  }

  public showInformation(message: string, title: string = 'Info'): void {
    this.toastService.info({detail: title, summary: message, duration: this.currentDuration})
  }
}
