import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailameliorationComponent } from './detail-amelioration.component';

describe('DetailameliorationComponent', () => {
  let component: DetailameliorationComponent;
  let fixture: ComponentFixture<DetailameliorationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailameliorationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailameliorationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
