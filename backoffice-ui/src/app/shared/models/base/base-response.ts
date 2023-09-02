export interface BaseResponse<T> {
  success: Boolean;
  Data: T;
}

export interface Response {
  success: Boolean;
  Data: string;
}
