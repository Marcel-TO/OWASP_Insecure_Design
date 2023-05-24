import { TestBed } from '@angular/core/testing';

import { DatabaseAccountService } from './database-account.service';

describe('DatabaseAccountService', () => {
  let service: DatabaseAccountService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatabaseAccountService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
