import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateAccountCardComponent } from './create-account-card/create-account-card.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    CreateAccountCardComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: CreateAccountCardComponent },
    ])
  ]
})
export class CreateAccountModule { }
