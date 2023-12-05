import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpFetcherService } from '../utils/http-fetcher.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  static readonly bearerTokenKey = 'bearer_token';


  #http = inject(HttpFetcherService)
  constructor() { }

  login(login: Login): Observable<string> {
    return this.#http.post('Login', login) as Observable<string>;
  }

}

export interface Login {
  username: string;
  password: string;
}
