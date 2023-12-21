import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminTabsComponent } from './admin-home/admin-tabs/admin-tabs.component';
import { PlanetCreateComponent } from './planet-home/planet-create/planet-create.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { PlanetHomeComponent } from './planet-home/planet-home.component';



@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminTabsComponent,
    PlanetCreateComponent,
    PlanetHomeComponent
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    MatCardModule,
    RouterModule.forChild([
      {
        path: '',
        component: AdminHomeComponent,
      }, {
        path: 'planets',
        component: PlanetCreateComponent
      }
    ])
  ]
})
export class AdminModule { }
