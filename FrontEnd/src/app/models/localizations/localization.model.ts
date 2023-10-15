import { BuildingModel } from "./building.model";

export class LocalizationModel {
  public id: number;
  public description: string;
  public level: string;
  public building: BuildingModel | null;

  constructor(id: number, description: string, level: string, building: BuildingModel | null){
    this.id = id;
    this.description = description;
    this.level = level
    this.building = building;
  }
}
