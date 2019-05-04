import { TestBed } from '@angular/core/testing';

import { JokenPoService } from './joken-po.service';

describe('JokenPoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: JokenPoService = TestBed.get(JokenPoService);
    expect(service).toBeTruthy();
  });
});
