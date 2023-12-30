import { Component, OnInit, inject } from '@angular/core';
import { Permission } from 'src/app/shared/app-constants';
import { CurrentUserService } from 'src/app/utils/current-user.service';

@Component({
  selector: 'admin-tabs',
  templateUrl: './admin-tabs.component.html',
  styleUrl: './admin-tabs.component.scss'
})
export class AdminTabsComponent implements OnInit {

  #currentUserService = inject(CurrentUserService);

  tabs: AdminTabConfig[] = [];

  ngOnInit(): void {

    if (this.#currentUserService.hasPermission(Permission.planetCreate)) {
      this.tabs.push({key: 'planets', label: 'Planets'} satisfies AdminTabConfig);
    }
  }

}

export interface AdminTabConfig {
  key: string;
  label: string;
}
