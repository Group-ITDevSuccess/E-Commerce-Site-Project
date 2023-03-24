import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { ErrorComponent } from './error/error.component';


@NgModule({
  imports: [
    RouterModule.forRoot([
      {path: '', component: HomeComponent},
      {path: 'home', component: HomeComponent},
      // {path: '', redirectTo: 'home', component: HomeComponent, pathMatch: 'full'},
      {path: '**', component: ErrorComponent},
    ]),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {}
