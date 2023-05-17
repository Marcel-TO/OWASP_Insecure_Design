import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/models/account';
import { Actuator } from 'src/app/models/actuator';
import { Modelfactory } from 'src/app/models/modelfactory';
import { TempSensor } from 'src/app/models/tempSensor';

@Component({
  selector: 'app-temp-settings',
  templateUrl: './temp-settings.component.html',
  styleUrls: ['./temp-settings.component.scss']
})
export class TempSettingsComponent {
  public currentUser?: string;
  public currentSensor?: TempSensor;

  public accounts: Account[] = [];
  public sensors: TempSensor[] = [];
  public actuators: Actuator[] = [];
  public degree = 20;
  public isOpen = false;
  private modelFactory = new Modelfactory()
  
  constructor(private activatedRoute: ActivatedRoute) {
    this.accounts = this.modelFactory.Accounts;
    this.sensors = this.modelFactory.TempSensors;
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
      this.sensors = this.modelFactory.getTempSensors(this.currentUser);
    }
  }
}
