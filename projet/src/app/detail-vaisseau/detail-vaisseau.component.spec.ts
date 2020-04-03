import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailVaisseauComponent } from './detail-vaisseau.component';

describe('DetailVaisseauComponent', () => {
  let component: DetailVaisseauComponent;
  let fixture: ComponentFixture<DetailVaisseauComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailVaisseauComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailVaisseauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
