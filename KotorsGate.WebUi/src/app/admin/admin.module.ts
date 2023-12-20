import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminTabsComponent } from './admin-tabs/admin-tabs.component';
import { PlanetCreateComponent } from './planet-create/planet-create.component';
import { TopBarItemComponent } from '../shared/top-bar/top-bar-item/top-bar-item.component';



@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminTabsComponent,
    PlanetCreateComponent
  ],
  imports: [
    CommonModule,
    TopBarItemComponent,
  ]
})
export class AdminModule { }
