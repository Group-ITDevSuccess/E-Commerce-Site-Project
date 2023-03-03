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

  private isFormSubmitted: boolean;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private clientsService: ListClientService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.clientForm = this.fb.group({
      FirstNameUser: ['', Validators.required],
      LastNameUser: ['', Validators.required],
      BirthDayUser: ['', Validators.required],
      GenreUser: ['', Validators.required],
    });
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

        // if (client.Id === null | client.Id === '') {

        // }
      }
    }
  }

}
