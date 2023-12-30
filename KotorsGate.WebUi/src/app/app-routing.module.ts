import { NgModule, inject } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CurrentUserService } from './utils/current-user.service';
import { Permission } from './shared/app-constants';

function checkPermission(permission: Permission): () => boolean {
  return () => {
    const service = inject(CurrentUserService);

    return service.hasPermission(permission);
  }
}

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
  }, {
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [checkPermission(Permission.adminTab)]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
