import { TestBed } from '@angular/core/testing';

import { TypeAmeliorationService } from './type-amelioration.service';

describe('TypeAmeliorationService', () => {
  let service: TypeAmeliorationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TypeAmeliorationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
