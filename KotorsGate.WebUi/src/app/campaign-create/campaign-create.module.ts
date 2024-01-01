import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignHomeComponent } from './campaign-home/campaign-home.component';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { ExistingCampaignComponent } from './existing-campaign/existing-campaign.component';
import { NewCampaignComponent } from './new-campaign/new-campaign.component';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';



@NgModule({
  declarations: [
    CampaignHomeComponent,
    ExistingCampaignComponent,
    NewCampaignComponent,
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
        component: NewCampaignComponent,
      }
    ])
  ]
})
export class CampaignCreateModule { }
