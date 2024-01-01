import { Component, OnInit, inject } from '@angular/core';
import { Campaign, CampaignService } from '../campaign.service';
import { Planet, PlanetService } from 'src/app/admin/planet-home/planet.service';

@Component({
  selector: 'new-campaign',
  templateUrl: './new-campaign.component.html',
  styleUrl: './new-campaign.component.scss'
})
export class NewCampaignComponent implements OnInit {

  #campaignService = inject(CampaignService);
  #planetService = inject(PlanetService);

  isSaving: boolean = false;

  errorMessage: string | undefined;

  campaign: Campaign = {id: 0, name: '', description: ''};
  planets: Planet[] = [];

  selectedPlanets: Planet[] = [];

  ngOnInit(): void {
    this.#planetService.getAllPlanets()
      .subscribe(planets => this.planets = planets);
  }

  save(): void {

    this.isSaving = true;

    this.#campaignService.createNewCampaign(this.campaign)
      .subscribe({
        next: campaign => {
          this.isSaving = false;
        }
      })

  }

}
