import { Component, OnInit, inject } from '@angular/core';
import { Campaign, CampaignService } from '../campaign.service';

@Component({
  selector: 'existing-campaign',
  templateUrl: './existing-campaign.component.html',
  styleUrl: './existing-campaign.component.scss'
})
export class ExistingCampaignComponent implements OnInit {

  #campaignService = inject(CampaignService);

  campaigns: Campaign[] = [];

  selectedCampaign: Campaign | undefined;

  ngOnInit(): void {

    this.#campaignService.getAllCampaigns()
      .subscribe({
        next: campaigns => this.campaigns = campaigns,
        error: err => console.error(err)
      });
  }

}
