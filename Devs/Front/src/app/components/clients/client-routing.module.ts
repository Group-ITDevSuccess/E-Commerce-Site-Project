import { ListClientsComponent } from './list-clients/list-clients.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    RouterModule.forChild([
      {path: 'clients', component:ListClientsComponent}
    ]),
  ],
  exports: [RouterModule]
})

export class ClientRoutingModule {}
