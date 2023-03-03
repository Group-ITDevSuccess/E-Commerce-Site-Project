import { ClientRoutingModule } from './client-routing.module';
import { NgModule } from '@angular/core';

import { SharedModule } from './../../shared/shared.module';
import { ListClientsComponent } from './list-clients/list-clients.component';
import { AddClientComponent } from './add-client/add-client.component';

@NgModule({
  declarations:[
    ListClientsComponent,
    AddClientComponent,
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
  ],
})

export class ClientModule { }
