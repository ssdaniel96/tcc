import { AddressModel } from "./address.model";

export class BuildingModel {
  public id: number;
  public description: string;
  public address: AddressModel | null;

  public get descriptionFormatted(): string{
   
    if (this.id == 0) {
      return 'Novo'
    }

    return this.description;
  }

  constructor(id: number, description: string, address: AddressModel | null = null){
    this.id = id;
    this.description = description;
    this.address = address;
  }
}
