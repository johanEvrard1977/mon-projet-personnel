import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PassInitComponent } from './pass-init.component';

describe('PassInitComponent', () => {
  let component: PassInitComponent;
  let fixture: ComponentFixture<PassInitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PassInitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PassInitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
