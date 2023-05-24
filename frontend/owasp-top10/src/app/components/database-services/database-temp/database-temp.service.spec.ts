import { TestBed } from '@angular/core/testing';

import { DatabaseTempService } from './database-temp.service';

describe('DatabaseTempService', () => {
  let service: DatabaseTempService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatabaseTempService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
