import { TestBed } from '@angular/core/testing';

import { ArticleWagesService } from './article-wages.service';

describe('ArticleWagesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ArticleWagesService = TestBed.get(ArticleWagesService);
    expect(service).toBeTruthy();
  });
});
