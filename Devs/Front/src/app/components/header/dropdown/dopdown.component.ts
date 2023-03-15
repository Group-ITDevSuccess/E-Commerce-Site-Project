import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-dropdown',
  templateUrl: './dropdown.component.html',
  styleUrls: ['./dropdown.component.css']
})
export class DropdownComponent implements OnInit {
  isOpen = false;

  constructor() { }

  ngOnInit(): void {}


  toggleDropdown() {
    this.isOpen = !this.isOpen;
  }
}
