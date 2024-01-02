import { Component, Input, OnInit, inject } from '@angular/core';
import { Campaign, CampaignPlanet, CampaignService } from '../campaign.service';
import { Planet, PlanetService } from 'src/app/admin/planet-home/planet.service';
import { Router } from '@angular/router';

@Component({
  selector: 'new-campaign',
  templateUrl: './campaign-overview.component.html',
  styleUrl: './campaign-overview.component.scss'
})
export class CampaignOverviewComponent implements OnInit {

  #campaignService = inject(CampaignService);
  #planetService = inject(PlanetService);
  #router = inject(Router);

  isSaving: boolean = false;

  errorMessage: string | undefined;

  @Input()
  campaign: Campaign = {id: 0, name: '', description: '', campaignPlanets: []};

  planets: Planet[] = [];

  selectedPlanets: Planet[] = [];

  ngOnInit(): void {
    this.#planetService.getAllPlanets()
      .subscribe(planets => this.planets = planets);
  }

  save(): void {

    this.isSaving = true;

    this.errorMessage = undefined;

    this.campaign.campaignPlanets = this.selectedPlanets.map(it => {
      return { id: 0, planetId: it.id, campaignId: this.campaign.id } satisfies CampaignPlanet
    })

    this.#campaignService.createNewCampaign(this.campaign)
      .subscribe({
        next: campaign => {
          this.campaign = campaign;
          this.isSaving = false;
          this.#router.navigate(['/', 'campaign-create', 'locations'], {queryParams: { id: campaign.id }});
        },
        error: err => {
          this.isSaving = false;
          this.errorMessage = 'Failed to save campaign';
          console.error(err);
        }
      })

  }

}
