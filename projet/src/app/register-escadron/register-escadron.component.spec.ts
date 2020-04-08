import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterEscadronComponent } from './register-escadron.component';

describe('RegisterEscadronComponent', () => {
  let component: RegisterEscadronComponent;
  let fixture: ComponentFixture<RegisterEscadronComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegisterEscadronComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterEscadronComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
