import { Component, Input } from '@angular/core';
import { Location } from '../location.service';

@Component({
  selector: 'location-item',
  templateUrl: './location-item.component.html',
  styleUrl: './location-item.component.scss'
})
export class LocationItemComponent {

  @Input()
  location: Location | undefined;

  mapConfig: MapConfig = { totalHorizontal: 1, totalVertical: 1 };

}

interface MapConfig {
  totalHorizontal: number;
  totalVertical: number;
}
