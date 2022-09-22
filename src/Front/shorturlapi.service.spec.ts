import { TestBed } from '@angular/core/testing';

import { ShorturlapiService } from './shorturlapi.service';

describe('ShorturlapiService', () => {
  let service: ShorturlapiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShorturlapiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
