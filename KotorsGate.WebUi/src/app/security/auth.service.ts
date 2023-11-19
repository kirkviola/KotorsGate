import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  #http = inject(HttpClient)
  constructor() { }

  login(login: Login): Observable<string> {
    return this.#http.post('echo/api/login', login) as Observable<string>;
  }

}

export interface Login {
  username: string;
  password: string;
}
