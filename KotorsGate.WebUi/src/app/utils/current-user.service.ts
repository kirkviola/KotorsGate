import { UserService } from './../users/user.service';
import { Injectable, inject } from '@angular/core';
import { UserAuth } from '../users/user.service';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  currentUser: UserAuth | undefined;

  #userService = inject(UserService)
  constructor() { }

  setCurrentUser(id: number): void {
    this.#userService.getCurrentUser(id)
      .subscribe({
        next: user => this.currentUser = user,
        error: err => console.error(err)
      });
  }
}
