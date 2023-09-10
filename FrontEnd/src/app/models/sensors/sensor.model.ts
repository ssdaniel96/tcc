import { LocalizationModel } from "../localizations/localization.model";

export class SensorModel {
  public id: number;
  public description: string;
  public location: LocalizationModel;

  constructor(id: number, description: string, location: LocalizationModel){
    this.id = id;
    this.description = description;
    this.location = location;
  }
}
