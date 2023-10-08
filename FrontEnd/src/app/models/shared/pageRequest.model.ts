export class PageRequest {
  pageNumber: number = 1;
  pageSize: number = 25;

  constructor(pageNumber: number = 1, pageSize: number = 25) {
    this.pageNumber = pageNumber;
    this.pageSize = pageSize;
  }
}
