import { TestBed } from '@angular/core/testing';

import { DatabaseLightService } from './database-light.service';

describe('DatabaseLightService', () => {
  let service: DatabaseLightService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatabaseLightService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
