import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';

@NgModule({
  imports: [
    RouterModule.forRoot([
      {path: 'home', component: HomeComponent},
      // {path: '', redirectTo: 'home', component: HomeComponent, pathMatch: 'full'},
      // {path: '**', redirectTo: 'home', component: HomeComponent, pathMatch: 'full'},
    ]),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule {}
