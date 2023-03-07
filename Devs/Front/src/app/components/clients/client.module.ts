import { ClientRoutingModule } from './client-routing.module';
import { NgModule } from '@angular/core';
import { Ng2SmartTableModule } from 'ng2-smart-table';​

import { SharedModule } from './../../shared/shared.module';
import { ListClientsComponent } from './list-clients/list-clients.component';
import { AddClientComponent } from './add-client/add-client.component';
import { DetailsClientsComponent } from './details-clients/details-clients.component';
import { EditClientComponent } from './edit-client/edit-client.component';

@NgModule({
  declarations:[
    ListClientsComponent,
    AddClientComponent,
    DetailsClientsComponent,
    EditClientComponent,
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
    Ng2SmartTableModule
  ],
})

export class ClientModule { }
