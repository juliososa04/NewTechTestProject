import { TestBed } from '@angular/core/testing';

import { BookrepositoryService } from './bookrepository.service';

describe('BookrepositoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BookrepositoryService = TestBed.get(BookrepositoryService);
    expect(service).toBeTruthy();
  });
});
