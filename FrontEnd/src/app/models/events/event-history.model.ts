import { Vector } from "./vector";

export class EventHistoryModel {
  public id: number = 0;
  public equipmentDescription: string = '';
  public equipmentRfTag: string = '';
  public locationDescription: string = '';
  public locationLevel: string = '';
  public locationBuilding: string = '';
  public locationZipCode: string = '';
  public locationNumber: string = '';
  public eventDateTime: string = '';
  public eventVector: Vector = 0 as Vector;

  constructor(
    id: number = 0,
    equipmentDescription: string = '',
    equipmentRfTag: string = '',
    locationDescription: string = '',
    locationLevel: string = '',
    locationBuilding: string = '',
    locationZipCode: string = '',
    locationNumber: string = '',
    eventDateTime: string = '',
    eventVector: Vector = 0 as Vector
  ){
    this.id = id;
    this.equipmentDescription = equipmentDescription;
    this.equipmentRfTag = equipmentRfTag;
    this.locationDescription = locationDescription;
    this.locationLevel = locationLevel;
    this.locationBuilding = locationBuilding;
    this.locationZipCode = locationZipCode;
    this.locationNumber = locationNumber;
    this.eventDateTime = eventDateTime;
    this.eventVector = eventVector;
  }
}
