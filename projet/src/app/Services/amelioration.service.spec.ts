import { TestBed } from '@angular/core/testing';

import { AmeliorationService } from './amelioration.service';

describe('AmeliorationService', () => {
  let service: AmeliorationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AmeliorationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
