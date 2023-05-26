import { Component } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';
import { SmartDevices } from 'src/app/models/database/SmartDevices';
import { Thermostat } from 'src/app/models/database/Temperature/Thermostat';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.scss']
})
export class AddDeviceComponent {
  public degree = 20
  public brightness = 0;
  public isOpen = false;
  public currentUser?: Account;
  private smartBulb?: SmartBulb;
  private smartJalousine?: SmartJalousine;
  private thermostat?: Thermostat;

  tempNameFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4)
  ]));
  lightNameFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4)
  ]));
  shutterNameFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4)
  ]));
  matcher = new MyErrorStateMatcher();
  
  constructor(private router: Router, private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
  }

  public onIncreaseTemp() {
    if (this.degree < 30) {
      this.degree += 1;
    }
  }

  public onDegreaseTemp() {
    if (this.degree > 14) {
      this.degree -= 1;
    }
  }

  public async onCreateLightSensor() {
    if (!this.lightNameFormControl.valid || this.smartBulb == null) {
      return;
    }
    let newname = (<HTMLInputElement>document.getElementById('new-light-name')).value;
    await this.dbService.CreateBulbSensor(newname, this.brightness, this.smartBulb.smartbulb_Id)
    if (this.currentUser != null) {
      this.router.navigate(['/settings'], {queryParams: {user: this.currentUser.account_Id}})
    }
  }

  public async onCreateTempSensor() {
    if (!this.tempNameFormControl.valid || this.thermostat == null) {
      return;
    }
    let newname = (<HTMLInputElement>document.getElementById('new-temp-name')).value;
    await this.dbService.CreateThermostatSensor(newname, this.degree, this.thermostat.thermostat_Id)
    if (this.currentUser != null) {
      this.router.navigate(['/settings'], {queryParams: {user: this.currentUser.account_Id}})
    }
  }

  public async onCreateShutterSensor() {
    if (!this.shutterNameFormControl.valid || this.smartJalousine == null) {
      return;
    }
    let newname = (<HTMLInputElement>document.getElementById('new-shutter-name')).value;
    await this.dbService.CreateJalousineSensor(newname, this.isOpen, this.smartJalousine.jalousine_Id)
    if (this.currentUser != null) {
      this.router.navigate(['/settings'], {queryParams: {user: this.currentUser.account_Id}})
    }
  }

  public onChangeShutterState() {
    this.isOpen = !this.isOpen;
  }

  private async updateDevices() {
    if (this.currentUser == null) {
      return;
    }
    let devices: SmartDevices = await this.dbService.GetAllDevicesFromAccount(this.currentUser.account_Id)
    this.smartBulb = devices.smartBulbs[0];
    this.smartJalousine = devices.smartJalousines[0];
    this.thermostat = devices.thermostats[0];
  }

  async ngOnInit() {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    let tempUser = await this.dbService.GetByIDAccount(id_query);
    let devices = document.getElementById('addDevices');
    let unsigned = document.getElementById('unsignedAddDeviceShowcase');

    if (tempUser.role == 'error') {
      if (devices != null) {
        devices.style.display = 'none'
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      this.currentUser = tempUser
      await this.updateDevices();
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}