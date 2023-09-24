import { Vector } from "./vector";

export class EventHistoryModel {
  public equipmentDescription: string = '';
  public equipmentRfTag: string = '';
  public locationDescription: string = '';
  public locationBuilding: string = '';
  public locationZipCode: string = '';
  public locationNumber: string = '';
  public eventDateTime: string = '';
  public eventVector: Vector = 0 as Vector;

  constructor(
    equipmentDescription: string = '',
    equipmentRfTag: string = '',
    locationDescription: string = '',
    locationBuilding: string = '',
    locationZipCode: string = '',
    locationNumber: string = '',
    eventDateTime: string = '',
    eventVector: Vector = 0 as Vector
  ){    
    this.equipmentDescription = equipmentDescription;
    this.equipmentRfTag = equipmentRfTag;
    this.locationDescription = locationDescription;
    this.locationBuilding = locationBuilding;
    this.locationZipCode = locationZipCode;
    this.locationNumber = locationNumber;
    this.eventDateTime = eventDateTime;
    this.eventVector = eventVector;
  }
}
