import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TempSettingsComponent } from './temp-settings.component';

describe('TempSettingsComponent', () => {
  let component: TempSettingsComponent;
  let fixture: ComponentFixture<TempSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TempSettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TempSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
