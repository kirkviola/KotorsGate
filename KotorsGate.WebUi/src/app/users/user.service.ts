import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpFetcherService } from '../utils/http-fetcher.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  #http = inject(HttpFetcherService);

  constructor() { }

  registerNewUser(user: User): Observable<User> {
    return this.#http.post('register', user) as Observable<User>;
  }
}

export interface User {
  id: number;
  username: string;
  password: string;
}
