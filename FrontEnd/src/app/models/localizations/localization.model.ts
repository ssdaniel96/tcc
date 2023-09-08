export class LocalizationModel {
  public id: number;
  public description: string;
  public level: number;

  constructor(id: number, description: string, level: number){
    this.id = id;
    this.description = description;
    this.level = level
  }
}
