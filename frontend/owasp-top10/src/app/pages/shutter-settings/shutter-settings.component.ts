import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShutterSensor } from 'src/app/models/shutterSensor';

@Component({
  selector: 'app-shutter-settings',
  templateUrl: './shutter-settings.component.html',
  styleUrls: ['./shutter-settings.component.scss']
})
export class ShutterSettingsComponent {
  public currentUser?: string;
  public currentSensor?: ShutterSensor;
  public sensors?: ShutterSensor[];
  public shutterOpen: boolean = false;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute) {
  }

  public onClickDrawer() {
    let menu = document.getElementById('shutterMenu');

    if (this.isOpen) {
      this.isOpen = false;
      if (menu != null) {
        menu.style.display = "none";
      }
    }
  }

  public onChangeShutter() {
    this.shutterOpen = !this.shutterOpen;
  }

  public selectDevice(sensor: ShutterSensor) {
    this.currentSensor = sensor;
    this.shutterOpen = this.currentSensor.isOpen;
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
    let unsigned = document.getElementById('unsignedShutterSettings');
    let devices = document.getElementById('device');
    if (this.currentUser == undefined) {
      if (devices != null) {
        devices.style.display = "none"
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
    
    this.sensors = [{id: '001', name: 'Shutter Livingroom', isOpen: true, account_id: 'testuser'},
    {id: '002', name: 'Shutter Kitchen', isOpen: false, account_id: 'testuser'},
    {id: '003', name: 'Shutter Bedroom', isOpen: true, account_id: 'testuser'},
    {id: '004', name: 'Shutter Terrace', isOpen: false, account_id: 'testuser'}];
  }
}
