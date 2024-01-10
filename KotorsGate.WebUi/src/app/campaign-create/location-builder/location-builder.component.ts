import { Component, Input, OnInit, inject } from '@angular/core';
import { CampaignService } from '../campaign.service';
import { Location } from '../location-builder/location.service';
import { ActivatedRoute } from '@angular/router';
import { switchMap, throwError } from 'rxjs';

@Component({
  selector: 'location-builder',
  templateUrl: './location-builder.component.html',
  styleUrl: './location-builder.component.scss'
})
export class LocationBuilderComponent implements OnInit {

  #campaignService = inject(CampaignService);
  #route = inject(ActivatedRoute);

  @Input()
  campaignId!: number | null;
  errorMessage!: string | null;

  locationEntries: LocationFormEntry[] = [];

  isLoading: boolean = false;

  ngOnInit(): void {

    this.#route.queryParamMap
      .pipe(switchMap(params => {
        this.isLoading = true;
        const id = params.get('id');

        if (id != null) {
          return this.#campaignService.getCampaignPlanetsByCampaignId(+id);
        } else {
          return throwError(() => {
            const err = new Error('No campaign found');
            return err;
          });
        }
      }))
      .subscribe({
        next: data => {
          this.locationEntries = data.map(it => {
            return {
              planetName: it.planetName,
              campaignPlanetId: it.campaignPlanetId,
              locations: []
            } satisfies LocationFormEntry;
          })
          this.isLoading = false;
        },
        error: err => {
          console.error(err);
          this.errorMessage = 'Failed to fetch campaign';
        }
      })

  }

}

export interface LocationFormEntry {
  planetName: string;
  campaignPlanetId: number;
  locations: Location[];
}
