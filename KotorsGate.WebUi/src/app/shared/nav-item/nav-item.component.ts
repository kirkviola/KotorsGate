import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
@Component({
  selector: 'top-bar-item',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    MatButtonModule,
  ],
  templateUrl: './nav-item.component.html',
  styleUrl: './nav-item.component.scss'
})
export class NavItemComponent {

  @Input()
  config!: LinkConfig;

}

export interface LinkConfig {
  name: string;
  route: string;
}
