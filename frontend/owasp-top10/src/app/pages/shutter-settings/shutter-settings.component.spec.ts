import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShutterSettingsComponent } from './shutter-settings.component';

describe('ShutterSettingsComponent', () => {
  let component: ShutterSettingsComponent;
  let fixture: ComponentFixture<ShutterSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShutterSettingsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShutterSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
