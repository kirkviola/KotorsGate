import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import { Planet, PlanetService } from '../planet.service';

@Component({
  selector: 'planet-create',
  templateUrl: './planet-create.component.html',
  styleUrl: './planet-create.component.scss'
})
export class PlanetCreateComponent {

  #planetService = inject(PlanetService);

  @Input()
  planet = { id: 0, name: '', description: '' } satisfies Planet;

  @Output()
  savedPlanet = new EventEmitter<Planet>();

  @Output()
  errorMessage = new EventEmitter<any>();

  save(): void {
    this.#planetService.createPlanet(this.planet)
      .subscribe({
        next: planet => this.savedPlanet.emit(planet),
        error: err => this.errorMessage.emit(err)
      });
  }

}
