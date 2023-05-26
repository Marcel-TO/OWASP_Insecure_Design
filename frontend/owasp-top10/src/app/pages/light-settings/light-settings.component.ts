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
  public currentActuator?: BulbActuator;
  public currentDevice?: SmartBulb;

  public devices?: SmartBulb[]
  public brightness?: number;
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

  public onSet() {
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
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
      // Get SmartBulbs
    }
  }
}
