import { ListClientService } from 'src/app/services/list-clients.service';
import { IClient } from 'src/app/models/Clients';
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-client',
  templateUrl: './add-client.component.html',
  styleUrls: ['./add-client.component.css']
})
export class AddClientComponent implements OnInit {

  @ViewChildren(FormControlName, {read: ElementRef}) inputElements: ElementRef[];

  public clientForm: FormGroup;

  public client: IClient;

  public errorMessage: string;

  public pageTitle: string;

  private isFormSubmitted: boolean;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private clientsService: ListClientService,
    private router: Router
  ) { }


  ngOnInit(): void {
    this.clientForm = this.fb.group({
      FirstNameClient: ['', Validators.required],
      LastNameClient: ['', Validators.required],
      BirthDayClient: ['', Validators.required],
      GenreClient: ['', Validators.required],
    });

    this.route.paramMap.subscribe(params => {
      const id = params.get('Id');
      console.log(id);
    })
  }



  public saveClient(){
    this.isFormSubmitted = true;

    this.clientForm.updateValueAndValidity({
      onlySelf: true,
      emitEvent: true
    });

    if (this.clientForm.valid) {
      if (this.clientForm.dirty) {
        const client:IClient = {
          ...this.client,
          ...this.clientForm.value
        };

        if (!client.Id){
          this.clientsService.createClient(client).subscribe({
            next: () => this.saveCompleted(),
            error: (err) => this.errorMessage = err
          });
        }else{
          this.clientsService.updateClient(client).subscribe({
            next: () => this.saveCompleted(),
            error: (err) => this.errorMessage = err
          })
        }
      }
    }
    console.log('Value : '+this.clientForm.value);
  }

  public saveCompleted(): void{
    this.clientForm.reset();
    this.router.navigate(['/clients']);
  }

  public backToList(){
    this.router.navigate(['/clients']);
  }

  public resetForm(){
    this.clientForm.reset();
  }

  public getSelectedClient(id: string): void{
    this.clientsService.getClientsById(id).subscribe((client: IClient) => {
      this.displayClient(client);
    })
  }

  public displayClient(client: IClient): void{
    this.client = client;

    if (this.client.Id) {
      this.pageTitle = 'Edit Client';
    }else{
      this.pageTitle = 'Add Client';
    }

    this.clientForm.patchValue({
      FirstNameClient: this.client.FirstNameClient,
      LastNameClient: this.client.LastNameClient,
      BirthDayClient: this.client.BirthDayClient,
      GenreClient: this.client.GenreClient
    });
  }

}
