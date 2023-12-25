import { TestBed } from '@angular/core/testing';

import { JeopardyClueService } from './jeopardy-clue.service';

describe('JeopardyClueService', () => {
  let service: JeopardyClueService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JeopardyClueService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
