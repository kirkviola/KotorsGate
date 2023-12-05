import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { SessionStorageService } from '../security/session-storage.service';
import { AuthenticationService } from '../security/authentication.service';

@Injectable({
  providedIn: 'root'
})
export class HttpFetcherService {

  #http = inject(HttpClient);
  #sessionService = inject(SessionStorageService);
  private readonly basePath = 'https://localhost:7276/api';

  constructor() { }

  get<T>(path: string, params?: QueryParams, headers?: Headers): Observable<T> {
    return this.#http.get<T>(`${this.basePath}/${path}`, {params: this.#buildParams(params), headers: this.#addHeaders(headers)}) as Observable<T>;
  }

  post<T>(path: string, body: any, params?: QueryParams, headers?: Headers): Observable<T> {
    return this.#http.post<T>(`${this.basePath}/${path}`, body, {params: this.#buildParams(params), headers: this.#addHeaders(headers)}) as Observable<T>;
  }


  #buildParams(params?: QueryParams): HttpParams | undefined {
    if (params != null) {
      const queryParams = new HttpParams();
      for (const param in params) {
        queryParams.append(param, params[param])
      }
      return queryParams;
    }

    return undefined;
  }

  #addHeaders(headers?: Headers): HttpHeaders | undefined {
    const httpHeaders = new HttpHeaders();
    const token = this.#sessionService.get(AuthenticationService.bearerTokenKey);

    if (token != null) {
      httpHeaders.append('Authorization', `Bearer ${token}`)
    }

    if (headers != null) {
      for (const header in headers) {
        httpHeaders.append(header, headers[header]);
      }
      return httpHeaders;
    }

    return httpHeaders;
  }
}

export interface QueryParams {
  [key: string]: QueryParamValue
}

export type QueryParamValue = string | number | boolean;

export interface Headers {
  [key: string]: string;
}
