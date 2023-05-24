import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackgroundLeftComponent } from './background-left.component';

describe('BackgroundLeftComponent', () => {
  let component: BackgroundLeftComponent;
  let fixture: ComponentFixture<BackgroundLeftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BackgroundLeftComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BackgroundLeftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
