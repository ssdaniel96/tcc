export class AddressModel {
  public id: number;
  public zipCode: string;
  public number: string;
  public complement: string | null;
  public observation: string | null;

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

  constructor(id: number, zipCode: string, number: string, complement: string | null = null, observation: string | null = null){
    this.id = id;
    this.zipCode = zipCode;
    this.number = number;
    this.complement = complement;
    this.observation = observation;
  }
}
