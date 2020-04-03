import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VaisseauComponent } from './vaisseau.component';

describe('VaisseauComponent', () => {
  let component: VaisseauComponent;
  let fixture: ComponentFixture<VaisseauComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VaisseauComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VaisseauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
