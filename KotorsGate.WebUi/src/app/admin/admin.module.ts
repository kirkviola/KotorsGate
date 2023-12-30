import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminTabsComponent } from './admin-home/admin-tabs/admin-tabs.component';
import { PlanetCreateComponent } from './planet-home/planet-create/planet-create.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { PlanetHomeComponent } from './planet-home/planet-home.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { PlanetDropdownComponent } from './planet-home/planet-dropdown/planet-dropdown.component';
import { FormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';



@NgModule({
  declarations: [
    AdminHomeComponent,
    AdminTabsComponent,
    PlanetCreateComponent,
    PlanetHomeComponent,
    PlanetDropdownComponent,
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    MatCardModule,
    MatFormFieldModule,
    MatSelectModule,
    MatSnackBarModule,
    MatInputModule,
    MatButtonModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: '',
        component: AdminHomeComponent,
      }
    ])
  ]
})
export class AdminModule { }
