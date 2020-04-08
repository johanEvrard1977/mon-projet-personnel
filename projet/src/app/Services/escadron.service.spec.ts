import { TestBed } from '@angular/core/testing';

import { EscadronService } from './escadron.service';

describe('EscadronService', () => {
  let service: EscadronService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EscadronService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
