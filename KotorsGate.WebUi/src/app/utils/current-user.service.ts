import { UserService, UserAuth } from './../users/user.service';
import { Injectable, inject } from '@angular/core';
import { Permission } from '../shared/app-constants';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  currentUser: UserAuth | undefined;
  currentUserSubject = new BehaviorSubject<UserAuth>({id: 0, username: '', permissions: []} satisfies UserAuth);

  #userService = inject(UserService)
  constructor() { }

  setCurrentUser(user: UserAuth): void {
    this.currentUser = user;

    this.currentUserSubject.next(user);
  }

  hasPermission(permission: Permission): boolean {
    if (this.currentUser != null) {
      return this.currentUser?.permissions.some(perm => perm === permission);
    }

    return false;
  }
}
