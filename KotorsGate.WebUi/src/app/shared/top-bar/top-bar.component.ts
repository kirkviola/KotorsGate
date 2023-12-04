import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkConfig, TopBarItemComponent } from './top-bar-item/top-bar-item.component';

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

  routes: LinkConfig[] = [];

  ngOnInit(): void {
    // TODO: As more navigation options become available with gated access, push them to the array here
    const login = { name: 'Login', route: '/login' } satisfies LinkConfig;

    this.routes.push(login);

  }
}
