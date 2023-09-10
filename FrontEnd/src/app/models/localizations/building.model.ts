import { AddressModel } from "./address.model";

export class BuildingModel {
  public id: number;
  public description: string;
  public address: AddressModel;

  constructor(id: number, description: string, level: number, address: AddressModel){
    this.id = id;
    this.description = description;
    this.address = address;
  }
}
