import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailAmeliorationBisComponent } from './detail-amelioration-bis.component';

describe('DetailAmeliorationBisComponent', () => {
  let component: DetailAmeliorationBisComponent;
  let fixture: ComponentFixture<DetailAmeliorationBisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailAmeliorationBisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailAmeliorationBisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
