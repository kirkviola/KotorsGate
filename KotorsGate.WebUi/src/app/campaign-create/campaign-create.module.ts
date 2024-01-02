import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignHomeComponent } from './campaign-home/campaign-home.component';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ExistingCampaignComponent } from './existing-campaign/existing-campaign.component';
import { CampaignOverviewComponent } from './new-campaign/campaign-overview.component';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { BackButtonComponent } from '../shared/back-button/back-button.component';
import { LocationBuilderComponent } from './location-builder/location-builder.component';
import { CampaignEditComponent } from './campaign-edit/campaign-edit.component';



@NgModule({
  declarations: [
    CampaignHomeComponent,
    ExistingCampaignComponent,
    CampaignOverviewComponent,
    LocationBuilderComponent,
    CampaignEditComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    MatProgressSpinnerModule,
    FormsModule,
    BackButtonComponent,
    RouterModule.forChild([
      {
        path: '',
        component: CampaignHomeComponent,
      },
      {
        path: 'existing',
        component: ExistingCampaignComponent,
      },
      {
        path: 'new',
        component: CampaignOverviewComponent,
      },
      {
        path: 'locations',
        component: LocationBuilderComponent,
      },
      {
        path: 'edit',
        component: CampaignEditComponent,
      }
    ])
  ]
})
export class CampaignCreateModule { }
