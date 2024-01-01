import { Injectable, inject } from '@angular/core';
import { HttpFetcherService } from '../utils/http-fetcher.service';
import { Observable } from 'rxjs';

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

  createNewCampaign(campaign: Campaign): Observable<Campaign> {
    return this.#http.post(this.basePath, campaign) as Observable<Campaign>;
  }
}

export interface Campaign {
  id: number;
  name: string;
  description: string;
}
