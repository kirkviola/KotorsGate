import { Injectable, inject } from '@angular/core';
import { HttpFetcherService } from '../utils/http-fetcher.service';
import { Observable } from 'rxjs';
import { Planet } from '../admin/planet-home/planet.service';

@Injectable({
  providedIn: 'root'
})
export class CampaignService {

  #http = inject(HttpFetcherService);
  private readonly basePath = 'campaigns';

  constructor() { }

  getAllCampaigns(): Observable<Campaign[]> {
    return this.#http.get(this.basePath) as Observable<Campaign[]>;
  }

  getOneCampaignById(id: number): Observable<Campaign> {
    return this.#http.get(`${this.basePath}/${id}`) as Observable<Campaign>;
  }

  createNewCampaign(campaign: CampaignWithPlanets): Observable<CampaignWithPlanets> {
    return this.#http.post(this.basePath, campaign) as Observable<CampaignWithPlanets>;
  }
}

export interface Campaign {
  id: number;
  name: string;
  description: string;

  campaignPlanets: CampaignPlanet[];
}

export interface CampaignPlanet {
  id: number;
  campaignId: number;
  planetId: number;

  planet: Planet;
  campaign: Campaign;
}

export interface CampaignWithPlanets {
  campaign: Campaign;
  planets: Planet[];
}
