import { Component, OnInit, inject } from '@angular/core';
import { Planet, PlanetService } from './planet.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'planet-home',
  templateUrl: './planet-home.component.html',
  styleUrl: './planet-home.component.scss'
})
export class PlanetHomeComponent implements OnInit {

  #planetService = inject(PlanetService);
  #snackBar = inject(MatSnackBar);

  snackBarMessage: string = '';

  planets: Planet[] = [];

  selectedPlanet = { id: 0, name: '', description: '' } satisfies Planet;

  ngOnInit(): void {

    this.#planetService.getAllPlanets()
      .subscribe({
        next: planets => this.planets = planets,
        error: err => console.error(err)
      });
  }

  updatePlanet(planet: Planet): void {
    this.selectedPlanet = planet;
  }

  saveSuccess(planet: Planet): void {
    // Add success message here to pop-up
    this.snackBarMessage = 'Successfully saved new planet!';

    this.ngOnInit();

    this.selectedPlanet = planet;

    this.openSnackBar();
  }

  saveFailure(): void {
    this.snackBarMessage = 'Failed to save new planet.';

    this.openSnackBar();
  }

  openSnackBar(): void {
    this.#snackBar.open(this.snackBarMessage, 'Close');
  }
}
