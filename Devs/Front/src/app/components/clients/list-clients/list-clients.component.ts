import { Component, OnInit } from '@angular/core';
import { ListClientService } from 'src/app/services/list-clients.service';
import { IClient } from 'src/app/models/Clients';

@Component({
  selector: 'app-list-clients',
  templateUrl: './list-clients.component.html',
  styleUrls: ['./list-clients.component.css']
})

export class ListClientsComponent implements OnInit {

  public title: string = 'List Clients';

  constructor(private listClientService: ListClientService) { }

  public clients : IClient[] = [];
  public filteredClients : IClient[] = [];

  private _clientFilter = 'mot';

  public errMsg: string;

  ngOnInit(): void {
    this.listClientService.getClients().subscribe({
      next: clients => {
        this.clients = clients;
        this.filteredClients = this.clients;
      },
      error: err => this.errMsg = err
    });
    this.clientFilter = '';
  }

  public get clientFilter(): string{
    return this._clientFilter;
  }

  public set clientFilter(filter: string){
    this._clientFilter = filter;

    this.filteredClients = this.clientFilter ? this.filterClients(this.clientFilter) : this.clients;
  }

  // public deleteClient(): void{
  //   if (confirm(`Are you sur to delete that !`)) {
  //     this.listClientService.deleteClient(this.clients.)
  //   }
  // }

  private filterClients(criteria: string): IClient[]{
    criteria = criteria.toLocaleLowerCase();

    const result = this.clients.filter(
      (client: IClient) => client.FirstNameClient.toLocaleLowerCase().indexOf(criteria) != -1
    );

    return result;
  }

}
