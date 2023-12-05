import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
@Component({
  selector: 'top-bar-item',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
  ],
  templateUrl: './top-bar-item.component.html',
  styleUrl: './top-bar-item.component.scss'
})
export class TopBarItemComponent {

  @Input()
  config!: LinkConfig;

}

export interface LinkConfig {
  name: string;
  route: string;
}
