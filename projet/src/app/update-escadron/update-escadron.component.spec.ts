import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateEscadronComponent } from './update-escadron.component';

describe('UpdateEscadronComponent', () => {
  let component: UpdateEscadronComponent;
  let fixture: ComponentFixture<UpdateEscadronComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateEscadronComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateEscadronComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
