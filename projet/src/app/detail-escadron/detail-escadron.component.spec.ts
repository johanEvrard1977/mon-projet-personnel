import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailEscadronComponent } from './detail-escadron.component';

describe('DetailEscadronComponent', () => {
  let component: DetailEscadronComponent;
  let fixture: ComponentFixture<DetailEscadronComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailEscadronComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailEscadronComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
