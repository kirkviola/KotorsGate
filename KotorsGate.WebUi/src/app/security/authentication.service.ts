import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpFetcherService } from '../utils/http-fetcher.service';
import { User } from '../users/user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  static readonly bearerTokenKey = 'bearer_token';


  #http = inject(HttpFetcherService)
  constructor() { }

  login(login: Login): Observable<LoginReponse> {
    return this.#http.post('Login', login) as Observable<LoginReponse>;
  }

}

export interface Login {
  username: string;
  password: string;
}

export interface LoginReponse {
  token: string;
  user: User
}
