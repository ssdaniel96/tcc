import { LocalizationModel } from "../localizations/localization.model";

export class InsertSensorModel {
  public id: number;
  public description: string;
  public locationId: number;

  constructor(id: number, description: string, locationId: number){
    this.id = id;
    this.description = description;
    this.locationId = locationId;
  }
}
