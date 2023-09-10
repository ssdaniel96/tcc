import { Component, OnInit } from '@angular/core';
import { EquipmentModel } from '../../models/equipments/equipment.model';
import { EquipamentosService } from '../../services/api/equipamentos.service';
import { InsertEquipmentModel } from '../../models/equipments/insert-equipment.model';

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
  
  constructor(private equipmentService: EquipamentosService){

  }

  ngOnInit(): void {
    this.search();
  }

  public newEquipmentToggle(): void{
    this.newEquipmentSetted = !this.newEquipmentSetted;
  }

  public search(): void {
    this.loading = true;
    this.equipmentService.get().subscribe(
      res => {
        this.equipments = res.data;
        this.loading = false;
      },
      error => {
        console.log('TODO: mostrar popup de erro');
        console.log(error);
        this.loading = false;
      }
    )
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
    this.equipmentService.insert(this.newEquipment).subscribe(
      res => {
        this.equipments.push(res.data);
        this.loading = false;
        this.changeToDefaultView();

      },
      error => {
        console.log('TODO: mostrar popup de erro');
        console.log(error);
        this.loading = false;     
 
      }
    )
  }

  public remove(id: number): void {
    this.loading = true;
    this.equipmentService.deleteById(id).subscribe(
      res => {
        this.equipments = this.equipments.filter(p => p.id != id)
        this.loading = false;
      },
      error => {
        console.log('TODO: mostrar popup de erro');
        console.log(error);
        this.loading = false;      
      }
    )
  }
}

