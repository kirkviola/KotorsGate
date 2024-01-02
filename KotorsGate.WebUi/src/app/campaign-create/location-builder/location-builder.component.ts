import { Component, Input, OnInit, inject } from '@angular/core';
import { Campaign, CampaignService } from '../campaign.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, throwError } from 'rxjs';
import { Planet } from 'src/app/admin/planet-home/planet.service';

@Component({
  selector: 'location-builder',
  templateUrl: './location-builder.component.html',
  styleUrl: './location-builder.component.scss'
})
export class LocationBuilderComponent implements OnInit {

  #campaignService = inject(CampaignService);
  #route = inject(ActivatedRoute);

  @Input()
  campaign!: Campaign | null;
  errorMessage!: string | null;

  planets: Planet[] = [];

  isLoading: boolean = false;

  ngOnInit(): void {

    this.#route.queryParamMap
      .pipe(switchMap(params => {
        this.isLoading = true;
        const id = params.get('id');

        if (id != null) {
          return this.#campaignService.getOneCampaignById(+id);
        } else {
          return throwError(() => {
            const err = new Error('No campaign found');
            return err;
          });
        }
      }))
      .subscribe({
        next: campaign => {
          this.campaign = campaign;
          this.#mapPlanets(campaign);
          this.isLoading = false;
        },
        error: err => {
          console.error(err);
          this.errorMessage = 'Failed to fetch campaign';
        }
      })

  }

  #mapPlanets(campaign: Campaign): void {
    campaign.campaignPlanets.forEach(it => {
      if (it.planet != null) {
        this.planets.push(it.planet);
      }
    })
  }

}
