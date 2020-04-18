import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PassOublieComponent } from './pass-oublie.component';

describe('PassOublieComponent', () => {
  let component: PassOublieComponent;
  let fixture: ComponentFixture<PassOublieComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PassOublieComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PassOublieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
