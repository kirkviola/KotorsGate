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

  getOneCampaignById(id: number): Observable<CampaignBasic> {
    return this.#http.get(`${this.basePath}/${id}`) as Observable<CampaignBasic>;
  }

  createNewCampaign(campaign: CampaignBasic): Observable<CampaignBasic> {
    return this.#http.post(this.basePath, campaign) as Observable<CampaignBasic>;
  }
}

export interface Campaign {
  id: number;
  name: string;
  description: string;
}

export interface CampaignBasic {
  campaign: Campaign,
  planets: Planet[]
}
