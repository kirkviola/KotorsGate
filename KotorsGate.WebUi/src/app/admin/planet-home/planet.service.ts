import { Observable } from 'rxjs';
import { Injectable, inject } from '@angular/core';
import { HttpFetcherService } from 'src/app/utils/http-fetcher.service';

@Injectable({
  providedIn: 'root'
})
export class PlanetService {

  #http = inject(HttpFetcherService);

  private readonly basePath = 'planets';

  constructor() { }

  getAllPlanets(): Observable<Planet[]> {
    return this.#http.get(this.basePath) as Observable<Planet[]>;
  }

  createPlanet(planet: Planet): Observable<Planet> {
    return this.#http.post(this.basePath, planet) as Observable<Planet>;
  }

  getPlanetById(id: number): Observable<Planet> {
    return this.#http.get(`${this.basePath}/${id}`) as Observable<Planet>;
  }
}

export interface Planet {
  id: number;
  name: string;
  description: string;
}
