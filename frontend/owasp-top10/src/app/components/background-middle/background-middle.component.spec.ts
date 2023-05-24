import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackgroundMiddleComponent } from './background-middle.component';

describe('BackgroundMiddleComponent', () => {
  let component: BackgroundMiddleComponent;
  let fixture: ComponentFixture<BackgroundMiddleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BackgroundMiddleComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BackgroundMiddleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
