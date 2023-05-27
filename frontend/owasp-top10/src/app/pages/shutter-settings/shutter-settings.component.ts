import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';
import { JalousineSensor } from 'src/app/models/database/Shutter/JalousineSensor';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';

@Component({
  selector: 'app-shutter-settings',
  templateUrl: './shutter-settings.component.html',
  styleUrls: ['./shutter-settings.component.scss']
})
export class ShutterSettingsComponent {
  public currentUser?: Account;
  public currentSensor?: JalousineSensor;
  public currentDevice?: SmartJalousine;
  public allSensors?: SmartJalousine[] = [];

  public shutterOpen: boolean = false;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute, private dbService:DatabaseService) {
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

  public selectDevice(sensor: JalousineSensor) {
    this.currentSensor = sensor;
    this.shutterOpen = JSON.parse(this.currentSensor.state);
  }

  public async onSet() {
    if (this.currentSensor == null || this.currentDevice == null) {
      return;
    }
    await this.dbService.UpdateJalousineSensor(this.currentSensor.sensor_Id, this.currentSensor.name, String(this.shutterOpen), this.currentSensor.jal_Id);
    this.allSensors = await this.dbService.GettAllSmartJalousinesFromAccount(this.currentDevice.acc_Id)
    this.currentDevice = this.allSensors[0];
  }

  async ngOnInit() {
    let unsigned = document.getElementById('unsignedShutterSettings');
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
      this.allSensors = await this.dbService.GettAllSmartJalousinesFromAccount(this.currentUser.account_Id);
      this.currentDevice = this.allSensors[0];

      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}
