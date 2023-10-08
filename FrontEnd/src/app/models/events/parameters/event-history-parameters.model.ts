import { PageRequest } from './../../shared/pageRequest.model';
export class EventHistoryParametersModel {
  public pageRequest: PageRequest = new PageRequest(1, 100);
  public equipmentId: number = 0;
  public sensorId: number = 0;
  public locationId: number = 0;
  public buildingId: number = 0;
  public addressId: number = 0;
  public vectorId: number = 0;
}
