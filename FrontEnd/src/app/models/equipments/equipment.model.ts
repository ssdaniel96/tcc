export class EquipmentModel {
  id: number = 0
  rfTag: string = '';
  description: string = '';

  constructor(id: number = 0, rfTag: string = '', description: string = ''){
    this.id = id;
    this.rfTag = rfTag;
    this.description = description;
  }
}
