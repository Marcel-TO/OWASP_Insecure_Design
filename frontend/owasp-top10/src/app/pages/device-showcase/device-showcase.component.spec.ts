import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeviceShowcaseComponent } from './device-showcase.component';

describe('DeviceShowcaseComponent', () => {
  let component: DeviceShowcaseComponent;
  let fixture: ComponentFixture<DeviceShowcaseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeviceShowcaseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeviceShowcaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
