import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignHomeComponent } from './campaign-home/campaign-home.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CampaignHomeComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: CampaignHomeComponent,
      }
    ])
  ]
})
export class CampaignCreateModule { }
