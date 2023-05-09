import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Actuator } from 'src/app/models/actuator';
import { TempSensor } from 'src/app/models/tempSensor';

@Component({
  selector: 'app-temp-settings',
  templateUrl: './temp-settings.component.html',
  styleUrls: ['./temp-settings.component.scss']
})
export class TempSettingsComponent {
  public currentUser?: string;
  public currentSensor?: TempSensor;
  public sensors?: TempSensor[];
  public actuators?: Actuator[];
  public degree = 20;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute) {
  }

  public onClickDrawer() {
    let menu = document.getElementById('tempMenu');

    if (this.isOpen) {
      this.isOpen = false;
      if (menu != null) {
        menu.style.display = "none";
      }
    }
  }

  public onIncreaseTemp() {
    if (this.currentSensor?.temp != null && this.currentSensor.temp < 30) {
      this.currentSensor.temp += 1;
    }
  }

  public onDegreaseTemp() {
    if (this.currentSensor?.temp != null && this.currentSensor.temp > 14) {
      this.currentSensor.temp -= 1;
    }
  }

  public selectDevice(sensor: TempSensor) {
    this.currentSensor = sensor;
    
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
    let unsigned = document.getElementById('unsignedTempSettings');
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
    
    this.sensors = [{id: '001', name: 'Temp-Livingroom', temp: 24, status: 'on', account_id: 'testuser'},
    {id: '002', name: 'Temp-Bedroom', temp: 18, status: 'on', account_id: 'testuser'},
    {id: '003', name: 'Temp-Kitchen', temp: 26, status: 'on', account_id: 'testuser'},
    {id: '004', name: 'Temp-Bathroom', temp: 25, status: 'on', account_id: 'testuser'}];
  }
}
