import { Injectable, inject } from '@angular/core';
import { HttpFetcherService } from 'src/app/utils/http-fetcher.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  #http = inject(HttpFetcherService);
  private readonly basePath = 'locations';

}

export interface Location {
  id: number;
  name: string;
  campaignPlanetId: number;
  coordinates: LocationSquare[];
}

export interface LocationSquare {
  XCoordinate: number;
  YCoordinate: number;
  isTraversable: boolean;
}
