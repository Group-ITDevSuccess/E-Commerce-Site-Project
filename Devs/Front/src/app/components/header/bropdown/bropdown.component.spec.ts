import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BropdownComponent } from './bropdown.component';

describe('BropdownComponent', () => {
  let component: BropdownComponent;
  let fixture: ComponentFixture<BropdownComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BropdownComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
