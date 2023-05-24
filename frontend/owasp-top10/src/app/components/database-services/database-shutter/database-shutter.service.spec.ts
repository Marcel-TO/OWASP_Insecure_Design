import { TestBed } from '@angular/core/testing';

import { DatabaseShutterService } from './database-shutter.service';

describe('DatabaseShutterService', () => {
  let service: DatabaseShutterService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DatabaseShutterService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
