import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostAdoptionComponent } from './post-adoption.component';

describe('PostAdoptionComponent', () => {
  let component: PostAdoptionComponent;
  let fixture: ComponentFixture<PostAdoptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostAdoptionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostAdoptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
