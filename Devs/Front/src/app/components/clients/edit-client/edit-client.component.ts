import { FormBuilder, FormControlName, FormGroup } from '@angular/forms';
import { Component, OnInit, ViewChildren, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IClient } from 'src/app/models/Clients';
import { ListClientService } from 'src/app/services/list-clients.service';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {

  @ViewChildren(FormControlName, {read: ElementRef}) inputElements: ElementRef[];
  public clientForm: FormGroup;

  public client: IClient = <IClient>{};

  constructor(
    private fb: FormBuilder,
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

  public displayClient(client: IClient): void{
    this.clientForm.patchValue({
      FirstNameClient: this.client.FirstNameClient,
      LastNameClient: this.client.LastNameClient,
      BirthDayClient: this.client.BirthDayClient,
      GenreClient: this.client.GenreClient
    });
  }

  public saveClientAfterUpdate(){

  }

}
