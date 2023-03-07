import { DetailsClientsComponent } from './details-clients/details-clients.component';
import { AddClientComponent } from './add-client/add-client.component';
import { ListClientsComponent } from './list-clients/list-clients.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { EditClientComponent } from './edit-client/edit-client.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      {path: 'clients', component:ListClientsComponent},
      {path: 'clients/:id', component:DetailsClientsComponent},
      {path: 'client/add', component:AddClientComponent},
      {path: 'client/edit/:id', component:AddClientComponent},
    ]),
  ],
  exports: [RouterModule]
})

export class ClientRoutingModule {}
