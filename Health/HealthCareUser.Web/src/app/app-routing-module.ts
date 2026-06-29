import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AllLoginComponent } from './Login/all-login/all-login';
import { RegisterComponent } from './Login/register/register';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },

  { path: 'login', component: AllLoginComponent },

  { path: 'register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
