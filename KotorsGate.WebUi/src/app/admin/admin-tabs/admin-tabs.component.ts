import { Component, OnInit, inject } from '@angular/core';
import { Permission } from 'src/app/shared/app-constants';
import { LinkConfig } from 'src/app/shared/top-bar/top-bar-item/top-bar-item.component';
import { CurrentUserService } from 'src/app/utils/current-user.service';

@Component({
  selector: 'admin-tabs',
  templateUrl: './admin-tabs.component.html',
  styleUrl: './admin-tabs.component.scss'
})
export class AdminTabsComponent implements OnInit {

  #currentUserService = inject(CurrentUserService);

  tabs: LinkConfig[] = [];

  ngOnInit(): void {
    if (this.#currentUserService.hasPermission(Permission.planetCreate)) {
      this.tabs.push({name: 'Planets', route: '/planets'} satisfies LinkConfig);
    }
  }

}
