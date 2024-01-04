import { Component, Input, OnInit, inject } from '@angular/core';
import { Campaign, CampaignBasic, CampaignService } from '../campaign.service';
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
  campaign: Campaign = {id: 0, name: '', description: ''};

  planets: Planet[] = [];

  selectedPlanets: Planet[] = [];

  ngOnInit(): void {
    this.#planetService.getAllPlanets()
      .subscribe(planets => this.planets = planets);
  }

  save(): void {

    this.isSaving = true;

    this.errorMessage = undefined;

    const newCampaign = { campaign: this.campaign, planets: this.selectedPlanets } satisfies CampaignBasic;
    this.#campaignService.createNewCampaign(newCampaign)
      .subscribe({
        next: response => {
          this.campaign = response.campaign;
          this.isSaving = false;
          this.#router.navigate(['/', 'campaign-create', 'locations'], {queryParams: { id: response.campaign.id }});
        },
        error: err => {
          this.isSaving = false;
          this.errorMessage = 'Failed to save campaign';
          console.error(err);
        }
      })

  }

}
