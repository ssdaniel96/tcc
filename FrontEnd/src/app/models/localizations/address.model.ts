export class AddressModel {
  public id: number;
  public zipCode: string;
  public number: string;
  public complement: string;
  public observation: string;

  constructor(id: number, zipCode: string, number: string, complement: string, observation: string){
    this.id = id;
    this.zipCode = zipCode;
    this.number = number;
    this.complement = complement;
    this.observation = observation;
  }
}
