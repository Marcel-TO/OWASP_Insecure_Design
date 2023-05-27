import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { Thermostat } from 'src/app/models/database/Temperature/Thermostat';
import { ThermostatSensor } from 'src/app/models/database/Temperature/ThermostatSensor';

@Component({
  selector: 'app-temp-settings',
  templateUrl: './temp-settings.component.html',
  styleUrls: ['./temp-settings.component.scss']
})
export class TempSettingsComponent {
  public currentUser?: Account;
  public currentSensor?: ThermostatSensor;
  public currentDevice?: Thermostat;
  public allDevices?: Thermostat[] = [];

  public degree = 20;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
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
    if (this.currentSensor?.temperature != null && this.currentSensor.temperature < 30) {
      this.currentSensor.temperature += 1;
    }
  }

  public onDegreaseTemp() {
    if (this.currentSensor?.temperature != null && this.currentSensor.temperature > 14) {
      this.currentSensor.temperature -= 1;
    }
  }

  public selectDevice(sensor: ThermostatSensor) {
    this.currentSensor = sensor;
  }

  public async onSet() {
    if (this.currentSensor == null || this.currentDevice == null) {
      return;
    }
    await this.dbService.UpdateThermostatSensor(this.currentSensor.sensor_Id, this.currentSensor.name, this.currentSensor.temperature, this.currentSensor.therm_Id);
    this.allDevices = await this.dbService.GettAllThermostatsFromAccount(this.currentDevice.acc_Id);
    this.currentDevice = this.allDevices[0];
  }

  async ngOnInit() {
    let unsigned = document.getElementById('unsignedTempSettings');
    let devices = document.getElementById('device');
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    let tempUser = await this.dbService.GetByIDAccount(id_query);
    
    if (tempUser.role == 'error') {
      if (devices != null) {
        devices.style.display = "none"
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      this.currentUser = tempUser;
      this.allDevices = await this.dbService.GettAllThermostatsFromAccount(this.currentUser.account_Id)
      this.currentDevice = this.allDevices[0];

      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}
