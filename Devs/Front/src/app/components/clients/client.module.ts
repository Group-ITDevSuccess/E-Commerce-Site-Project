import { ClientRoutingModule } from './client-routing.module';
import { ListClientsComponent } from './list-clients/list-clients.component';
import { NgModule } from '@angular/core';

@NgModule({
  declarations:[
    ListClientsComponent,
  ],
  imports: [
    ClientRoutingModule,
  ],
})

export class ClientModule { }
