import { UserService } from './../users/user.service';
import { Injectable, inject } from '@angular/core';
import { UserAuth } from '../users/user.service';
import { Permission } from '../shared/app-constants';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  currentUser: UserAuth | undefined;

  #userService = inject(UserService)
  constructor() { }

  setCurrentUser(user: UserAuth): void {
    this.currentUser = user;
  }

  hasPermission(permission: Permission): boolean {
    if (this.currentUser != null) {
      return this.currentUser?.permissions.some(perm => perm === permission);
    }

    return false;
  }
}
