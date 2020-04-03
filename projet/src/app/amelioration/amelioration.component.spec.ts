import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmeliorationComponent } from './amelioration.component';

describe('AmeliorationComponent', () => {
  let component: AmeliorationComponent;
  let fixture: ComponentFixture<AmeliorationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmeliorationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmeliorationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
