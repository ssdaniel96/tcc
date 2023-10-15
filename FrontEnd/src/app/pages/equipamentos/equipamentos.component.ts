import { Component, OnInit } from '@angular/core';
import { EquipmentModel } from '../../models/equipments/equipment.model';
import { EquipamentosService } from '../../services/api/equipamentos.service';
import { InsertEquipmentModel } from '../../models/equipments/insert-equipment.model';
import { MessageDisplayService } from 'src/app/services/message-display.service';

@Component({
  selector: 'app-equipamentos',
  templateUrl: './equipamentos.component.html',
  styleUrls: ['./equipamentos.component.scss']
})
export class EquipamentosComponent implements OnInit {

  public newEquipment: InsertEquipmentModel = new InsertEquipmentModel();
  public equipments: EquipmentModel[] = [];

  public loading: boolean = false;
  public newEquipmentSetted: boolean = false;

  constructor(
    private equipmentService: EquipamentosService,
    private messageService: MessageDisplayService
  ) {

  }

  ngOnInit(): void {
    this.search();
  }

  public newEquipmentToggle(): void {
    this.newEquipmentSetted = !this.newEquipmentSetted;
  }

  public search(): void {
    this.loading = true;
    this.equipmentService.get().subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.equipments = res.data;
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }

  public cancel(): void {
    this.changeToDefaultView();
  }

  public changeToDefaultView(): void {
    this.newEquipment = new InsertEquipmentModel();
    this.newEquipmentToggle();
  }

  public save(): void {
    this.loading = true;
    this.equipmentService.insert(this.newEquipment).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.equipments.push(res.data);
          this.changeToDefaultView();
          this.messageService.showSuccess('O equipamento foi salvo com sucesso');
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }

  public remove(id: number): void {
    this.loading = true;
    this.equipmentService.deleteById(id).subscribe({
      next: res => {
        if (res.isSuccessfully) {
          this.equipments = this.equipments.filter(p => p.id != id)
          this.messageService.showSuccess('O equipamento foi removido com sucesso');
        } else {
          this.messageService.showError(res.error);
        }
      },
      error: error => {
        this.messageService.showError('Ocorreu um erro interno, mais detalhes nos logs do navegador');
        console.log(error);
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }
}

