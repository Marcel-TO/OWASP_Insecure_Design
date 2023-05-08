import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LightSettingsComponent } from './light-settings.component';

describe('LightSettingsComponent', () => {
  let component: LightSettingsComponent;
  let fixture: ComponentFixture<LightSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LightSettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LightSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
