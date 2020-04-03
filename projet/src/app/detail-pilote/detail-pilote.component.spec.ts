import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailPiloteComponent } from './detail-pilote.component';

describe('DetailPiloteComponent', () => {
  let component: DetailPiloteComponent;
  let fixture: ComponentFixture<DetailPiloteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailPiloteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailPiloteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
