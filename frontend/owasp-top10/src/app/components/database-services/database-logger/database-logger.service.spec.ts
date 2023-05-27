import { TestBed } from '@angular/core/testing';

import { DatabaseLoggerService } from './database-logger.service';

describe('DatabaseLoggerService', () => {
  let service: DatabaseLoggerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatabaseLoggerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
