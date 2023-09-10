export class AddressModel {
  public id: number;
  public zipCode: string;
  public number: string;
  public complement: string;
  public observation: string;

  public get description(): string{
   
    if (this.id == 0) {
      return 'Novo'
    }

    let description = `CEP: ${this.zipCode}, nº ${this.number}`

    if (this.complement != null){
      description += `, ${this.complement}`
    }

    if (this.observation != null){
      description += `, ${this.observation}`
    }

    return description;
  }

  constructor(id: number, zipCode: string, number: string, complement: string, observation: string){
    this.id = id;
    this.zipCode = zipCode;
    this.number = number;
    this.complement = complement;
    this.observation = observation;
  }
}
