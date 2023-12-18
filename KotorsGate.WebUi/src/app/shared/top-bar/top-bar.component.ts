import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkConfig, TopBarItemComponent } from './top-bar-item/top-bar-item.component';
import { CurrentUserService } from 'src/app/utils/current-user.service';
import { Permission } from '../app-constants';

@Component({
  selector: 'top-bar',
  standalone: true,
  imports: [
    CommonModule,
    TopBarItemComponent,
  ],
  templateUrl: './top-bar.component.html',
  styleUrl: './top-bar.component.scss'
})
export class TopBarComponent implements OnInit {

  #currentUserService = inject(CurrentUserService);

  routes: LinkConfig[] = [];

  ngOnInit(): void {
    // TODO: As more navigation options become available with gated access, push them to the array here
    const login = { name: 'Login', route: '/login' } satisfies LinkConfig;

    this.routes.push(login);

    if (this.#currentUserService.hasPermission(Permission.campaignCreator)) {
      this.routes.push({name: 'Create Campaign', route: 'campaign-create'} satisfies LinkConfig);
    }

  }
}
