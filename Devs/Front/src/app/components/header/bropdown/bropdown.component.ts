import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-bropdown',
  templateUrl: './bropdown.component.html',
  styleUrls: ['./bropdown.component.css']
})
export class BropdownComponent implements OnInit {
  isOpen = false;

  constructor() { }

  ngOnInit(): void {}


  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
