import { TestBed } from '@angular/core/testing';

import { HomeItemHttpService } from './home-item-http.service';

describe('HomeItemHttpService', () => {
  let service: HomeItemHttpService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HomeItemHttpService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
