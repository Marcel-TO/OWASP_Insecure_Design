import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Actuator } from 'src/app/models/actuator';
import { LightSensor } from 'src/app/models/lightSensor';

@Component({
  selector: 'app-light-settings',
  templateUrl: './light-settings.component.html',
  styleUrls: ['./light-settings.component.scss']
})
export class LightSettingsComponent implements OnInit{
  public currentUser?: string;
  public currentSensor?: LightSensor;
  public sensors?: LightSensor[];
  public actuators?: Actuator[];
  public brightness?: number;
  public warmness?: number;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute) {
  }
  
  public onClickDrawer() {
    let menu = document.getElementById('lightMenu');

    if (this.isOpen) {
      this.isOpen = false;
      if (menu != null) {
        menu.style.display = "none";
      }
    }
  }

  public onSet() {
  }

  public selectDevice(sensor: LightSensor) {
    this.currentSensor = sensor;
    this.brightness = this.currentSensor.brightness;
    this.warmness = this.currentSensor.warmness;
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

    this.sensors = [{id: '001', name: 'Light_Livingroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '002', name: 'Light_Kitchen', brightness: 8, warmness: 3, account_id: 'testuser'},
    {id: '003', name: 'Light_Bedroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '004', name: 'Light_Upstairs', brightness: 0, warmness: 0, account_id: 'testuser'}];
  }
}
