import { TestBed } from '@angular/core/testing';

import { AuthorRepositoryService } from './author-repository.service';

describe('AuthorRepositoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AuthorRepositoryService = TestBed.get(AuthorRepositoryService);
    expect(service).toBeTruthy();
  });
});
