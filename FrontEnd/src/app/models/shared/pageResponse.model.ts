export class PageResponse<T> {
  public pageNumber: number;
  public pageSize: number;
  public itemsSize: number;
  public totalRows: number;
  public data: T[];


  constructor(pageNumber: number, pageSize: number, totalRows: number, data: T[]) {
    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
    this.totalRows = totalRows;
    this.data = data;
    this.itemsSize = data.length;
  }
}
