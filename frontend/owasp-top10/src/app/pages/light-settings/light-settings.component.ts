import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/models/account';
import { Actuator } from 'src/app/models/actuator';
import { LightSensor } from 'src/app/models/lightSensor';
import { Modelfactory } from 'src/app/models/modelfactory';

@Component({
  selector: 'app-light-settings',
  templateUrl: './light-settings.component.html',
  styleUrls: ['./light-settings.component.scss']
})
export class LightSettingsComponent implements OnInit{
  public currentUser?: string;
  public currentSensor?: LightSensor;

  public accounts: Account[] = [];
  public sensors: LightSensor[] = [];
  public actuators: Actuator[] = [];
  public brightness?: number;
  public warmness?: number;
  public isOpen = false;
  private modelFactory = new Modelfactory()
  
  constructor(private activatedRoute: ActivatedRoute) {
    this.accounts = this.modelFactory.Accounts;
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

  private checkUser(id:string) {
    for (let user of this.accounts) {
      if (id == user.id) {
        return id;
      }
    }
    return undefined
  }

  ngOnInit(): void {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    this.currentUser = this.checkUser(id_query);

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
      this.sensors = this.modelFactory.getLightSensors(this.currentUser);
    }
  }
}
