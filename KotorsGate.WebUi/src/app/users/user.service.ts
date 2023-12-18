import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpFetcherService, QueryParams } from '../utils/http-fetcher.service';
import { Permission } from '../shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  #http = inject(HttpFetcherService);

  private readonly basePath = 'users';

  constructor() { }

  registerNewUser(user: User): Observable<User> {
    return this.#http.post(`${this.basePath}/register`, user) as Observable<User>;
  }

  getCurrentUser(id: number): Observable<UserAuth> {
    return this.#http.get(`${this.basePath}/authentication`, {id: id} satisfies QueryParams) as Observable<UserAuth>;
  }
}

export interface User {
  id: number;
  username: string;
  password: string;
}

export interface UserCreation {
  username: string;
  passwordInit: string;
  passwordVerified: string;
}

export interface UserAuth {
  id: number;
  username: string;
  permissions: Permission[];
}
