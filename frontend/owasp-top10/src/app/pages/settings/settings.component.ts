import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CustomValidators } from 'src/app/models/custom-validators';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { Thermostat } from 'src/app/models/database/Temperature/Thermostat';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';
import { ErrorStateMatcher } from '@angular/material/core';
import { SmartDevices } from 'src/app/models/database/SmartDevices';
@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  public currentUser?: Account;
  public accounts: Account[] = [];
  public thermostat?: Thermostat;
  public smartBulb?: SmartBulb;
  public smartJalousine?: SmartJalousine;
  
  matcher = new MyErrorStateMatcher();
  usernameFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(3),
    CustomValidators.patternValidator(/^([^0-9]*)$/, { hasLetters: true}) // Regex expression for everything except numbers
  ]))
  passwordFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4),
    CustomValidators.patternValidator(/\d/, { hasNumber: true }),
    CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
    CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true })
  ]));
  isHiding = true;

  constructor(private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
  }

  public onChangeSensorName(newname:string) {
    console.log(newname)
  }

  async ngOnInit() {
    let unsigned = document.getElementById('unsignedSettings');
    let devices = document.getElementById('device');
    let adminSettings = document.getElementById('admin-settings');
    
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
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }

      this.currentUser = tempUser
      console.log(this.currentUser.account_Id)
      let devices: SmartDevices = await this.dbService.GetAllDevicesFromAccount(this.currentUser.account_Id)
      this.smartBulb = devices.smartBulbs[0];
      this.smartJalousine = devices.smartJalousines[0];
      this.thermostat = devices.thermostats[0];
      console.log(this.smartBulb)

      if (this.currentUser.role != 'admin') {
        if (adminSettings != null) {
          adminSettings.style.display = 'none';
        }
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