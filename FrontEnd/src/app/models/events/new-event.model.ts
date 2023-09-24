import { Vector } from 'src/app/models/events/vector';
export class NewEventModel {
  public rfTag: string | null = '';
  public vector: Vector = 0 as Vector;
  public locationId: number = 0;

  constructor(rfTag: string | null, vector: Vector | number, locationId: number ){
    this.rfTag = rfTag;
    this.vector = vector as Vector;
    this.locationId = locationId;
  }
}
