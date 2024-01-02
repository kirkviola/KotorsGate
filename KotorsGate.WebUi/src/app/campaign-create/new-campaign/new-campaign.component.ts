import { Component, OnInit, inject } from '@angular/core';
import { Campaign, CampaignPlanet, CampaignService } from '../campaign.service';
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

  campaign: Campaign = {id: 0, name: '', description: '', campaignPlanets: []};

  planets: Planet[] = [];

  selectedPlanets: Planet[] = [];

  ngOnInit(): void {
    this.#planetService.getAllPlanets()
      .subscribe(planets => this.planets = planets);
  }

  save(): void {

    this.isSaving = true;

    this.campaign.campaignPlanets = this.selectedPlanets.map(it => {
      return { id: 0, planetId: it.id, campaignId: this.campaign.id } satisfies CampaignPlanet
    })

    this.#campaignService.createNewCampaign(this.campaign)
      .subscribe({
        next: () => {
          this.isSaving = false;
        },
        error: err => {
          this.isSaving = false;
          this.errorMessage = 'Failed to save campaign';
          console.error(err);
        }
      })

  }

}
