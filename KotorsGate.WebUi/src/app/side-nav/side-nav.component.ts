import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkConfig } from '../shared/nav-item/nav-item.component';
import { CurrentUserService } from '../utils/current-user.service';
import { Permission } from '../shared/app-constants';
import { RouterModule } from '@angular/router';
import { MatListModule } from '@angular/material/list';

@Component({
  selector: 'side-nav',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatListModule,
  ],
  templateUrl: './side-nav.component.html',
  styleUrl: './side-nav.component.scss'
})
export class SideNavComponent implements OnInit {

  #currentUserService = inject(CurrentUserService);

  routes: LinkConfig[] = [];

  ngOnInit(): void {
    const login = { name: 'Login', route: '/login' } satisfies LinkConfig;


    this.#currentUserService.currentUserSubject.subscribe({
      next: user => {
        this.routes = [];
        this.routes.push(login);
        // TODO: As more navigation options become available with gated access, push them to the array here
        if (user != null) {
          if (user.permissions.find(permission => permission === Permission.adminTab)) {
            this.routes.push({name: 'Admin', route: 'admin'} satisfies LinkConfig);
          }

          if (user.permissions.find(permission => permission === Permission.campaignCreator)) {
            this.routes.push({name: 'Create Campaign', route: 'campaign-create'} satisfies LinkConfig);
          }
        }
      }
    })
  }

}
