import { TestBed, inject } from '@angular/core/testing';

import { ElixrService } from './elixr.service';

describe('StatModsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ElixrService]
    });
  });

  it('should ...', inject([ElixrService], (service: ElixrService) => {
    expect(service).toBeTruthy();
  }));
});
