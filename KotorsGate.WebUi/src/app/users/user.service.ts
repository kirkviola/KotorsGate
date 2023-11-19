import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  #http = inject(HttpClient);

  constructor() { }

  registerNewUser(user: User): Observable<User> {
    return this.#http.post('echo/api/register', user) as Observable<User>;
  }
}

export interface User {
  id: number;
  username: string;
  password: string;
}
