import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  }, {
    path: 'login',
    loadComponent: () => import('./login/login.component').then(c => c.LoginComponent),
  }, {
    path: 'register',
    loadComponent: () => import('./create-account/create-account-card.component').then(c => c.CreateAccountCardComponent),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
