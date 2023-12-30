import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Planet } from '../planet.service';

@Component({
  selector: 'planet-dropdown',
  templateUrl: './planet-dropdown.component.html',
  styleUrl: './planet-dropdown.component.scss'
})
export class PlanetDropdownComponent {

  @Input()
  planets: Planet[] = [];

  @Output()
  selectedPlanet = new EventEmitter<Planet>();

  updateSelectedPlanet(planet: Planet): void {
    this.selectedPlanet.emit(planet);
  }

}
