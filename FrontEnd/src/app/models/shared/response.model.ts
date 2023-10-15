export class Response<T> {
  public isSuccessfully: boolean = false;
  public isFailed: boolean = true;
  public data: T;
  public error: string = '';

  constructor(isSuccessfully: boolean, data: T, error: string) {
    this.isSuccessfully = true;
    this.isFailed = !isSuccessfully;
    this.data = data;
    this.error = error;
  }

}

export class SimpleResponse {
  public isSuccessfully: boolean = false;
  public isFailed: boolean = true;
  public error: string = ''
}
