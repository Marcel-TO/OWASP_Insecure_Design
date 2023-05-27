import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { BulbActuator } from 'src/app/models/database/Light/BulbActuator';
import { BulbSensor } from 'src/app/models/database/Light/BulbSensor';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';

@Component({
  selector: 'app-light-settings',
  templateUrl: './light-settings.component.html',
  styleUrls: ['./light-settings.component.scss']
})
export class LightSettingsComponent implements OnInit{
  public currentUser?: Account;
  public currentSensor?: BulbSensor;
  public currentDevice?: SmartBulb;
  public allDevices?: SmartBulb[] = [];

  public brightness: number = 0;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
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

  public async onSet() {
    if (this.currentSensor == null || this.currentDevice == null) {
      return;
    }
    await this.dbService.UpdateBulbSensor(this.currentSensor.sensor_Id, this.currentSensor.name, this.brightness, this.currentSensor.bulb_Id);
    this.allDevices = await this.dbService.GettAllSmartBulbsFromAccount(this.currentDevice.acc_Id)
    this.currentDevice = this.allDevices[0];
  }

  public selectDevice(sensor: BulbSensor) {
    this.currentSensor = sensor;
    this.brightness = this.currentSensor.brightness;
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
      this.currentUser = tempUser
      this.allDevices = await this.dbService.GettAllSmartBulbsFromAccount(this.currentUser.account_Id)
      this.currentDevice = this.allDevices[0];

      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}
