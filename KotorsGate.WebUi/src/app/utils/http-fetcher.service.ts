import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpFetcherService {

  #http = inject(HttpClient);

  constructor() { }

  get<T>(path: string, params?: QueryParams): Observable<T> {
    return this.#http.get<T>(`/echo/api/${path}`, {params: this.#buildParams(params)}) as Observable<T>;
  }


  #buildParams(params?: QueryParams): HttpParams | undefined {
    return params != null ? new HttpParams().set(params.key, params.value) : undefined;
  }
}

export interface QueryParams {
  key: string;
  value: string | boolean | number;
}
