import { Vector } from 'src/app/models/events/vector';
export class NewEventModel {
  public rfTag: string | null = '';
  public vector: Vector = 0 as Vector;
  public sensorId: number = 0;

  constructor(rfTag: string | null, vector: Vector | number, sensorId: number){
    this.rfTag = rfTag;
    this.vector = vector as Vector;
    this.sensorId = sensorId;
  }
}
