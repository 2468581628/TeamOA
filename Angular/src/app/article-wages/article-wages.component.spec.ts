import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleWagesComponent } from './article-wages.component';

describe('ArticleWagesComponent', () => {
  let component: ArticleWagesComponent;
  let fixture: ComponentFixture<ArticleWagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ArticleWagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ArticleWagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
