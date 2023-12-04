import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpFetcherService {

  #http = inject(HttpClient);

  constructor() { }

  get<T>(path: string, params?: QueryParams[], headers?: Header[]): Observable<T> {
    return this.#http.get<T>(`/echo/api/${path}`, {params: this.#buildParams(params), headers: this.#addHeaders(headers)}) as Observable<T>;
  }

  post<T>(path: string, body: any, params?: QueryParams[], headers?: Header[]): Observable<T> {
    return this.#http.post<T>(`/echo/api/${path}`, {body: body, params: this.#buildParams(params), headers: this.#addHeaders(headers)}) as Observable<T>;
  }


  #buildParams(params?: QueryParams[]): HttpParams | undefined {
    if (params != null) {
      let queryParams = new HttpParams();
      params.map(param => queryParams.append(param.key, param.value));
      return queryParams;
    }

    return undefined;
  }

  #addHeaders(headers?: Header[]): HttpHeaders | undefined {
    if (headers != null) {
      let httpHeaders = new HttpHeaders();
      headers.map(header => httpHeaders.append(header.name, header.value));
      return httpHeaders;
    }

    return undefined;
  }
}

export interface QueryParams {
  key: string;
  value: string | boolean | number;
}

export interface Header {
  name: string;
  value: string;
}
