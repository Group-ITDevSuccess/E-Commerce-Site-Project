import { IClient } from 'src/app/models/Clients';
import { ListClientService } from 'src/app/services/list-clients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-details-clients',
  templateUrl: './details-clients.component.html',
  styleUrls: ['./details-clients.component.css']
})
export class DetailsClientsComponent implements OnInit {
  public client: IClient = <IClient>{};
  constructor(
    private route: ActivatedRoute,
    private clientService: ListClientService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const Id : string = this.route.snapshot.paramMap.get('id');
    this.clientService.getClients().subscribe((clients: IClient[]) => {
      this.client = clients.find(client => client.Id == Id);
      console.log('client: ', this.client);
    });
  }

 

  public backToList(){
    this.router.navigate(['/clients']);
  }
}
