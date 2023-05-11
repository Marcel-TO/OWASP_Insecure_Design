import { Component, OnInit, ViewChild } from '@angular/core';
import { MatAccordion } from '@angular/material/expansion';
import { ActivatedRoute } from '@angular/router';
import { LightSensor } from 'src/app/models/lightSensor';
import { ShutterSensor } from 'src/app/models/shutterSensor';
import { TempSensor } from 'src/app/models/tempSensor';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  @ViewChild(MatAccordion) accordion?: MatAccordion;
  public currentUser?: string;
  public tempSensors?: TempSensor[];
  public lightSensors?: LightSensor[];
  public shutterSensors?: ShutterSensor[];

  constructor(private activatedRoute: ActivatedRoute) {
    this.tempSensors = [{id: '001', name: 'Temp-Livingroom', temp: 24, status: 'on', account_id: 'testuser'},
    {id: '002', name: 'Temp-Bedroom', temp: 18, status: 'on', account_id: 'testuser'},
    {id: '003', name: 'Temp-Kitchen', temp: 26, status: 'on', account_id: 'testuser'},
    {id: '004', name: 'Temp-Bathroom', temp: 25, status: 'on', account_id: 'testuser'}];
    this.lightSensors = [{id: '001', name: 'Light_Livingroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '002', name: 'Light_Kitchen', brightness: 8, warmness: 3, account_id: 'testuser'},
    {id: '003', name: 'Light_Bedroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '004', name: 'Light_Upstairs', brightness: 0, warmness: 0, account_id: 'testuser'}];
    this.shutterSensors = [{id: '001', name: 'Shutter Livingroom', isOpen: true, account_id: 'testuser'},
    {id: '002', name: 'Shutter Kitchen', isOpen: false, account_id: 'testuser'},
    {id: '003', name: 'Shutter Bedroom', isOpen: true, account_id: 'testuser'},
    {id: '004', name: 'Shutter Terrace', isOpen: false, account_id: 'testuser'}];
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
    let unsigned = document.getElementById('unsignedSettings');
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
  }

}
