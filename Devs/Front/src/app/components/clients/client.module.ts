import { ClientRoutingModule } from './client-routing.module';
import { NgModule } from '@angular/core';

import { SharedModule } from './../../shared/shared.module';
import { ListClientsComponent } from './list-clients/list-clients.component';

@NgModule({
  declarations:[
    ListClientsComponent,
  ],
  imports: [
    SharedModule,
    ClientRoutingModule,
  ],
})

export class ClientModule { }
