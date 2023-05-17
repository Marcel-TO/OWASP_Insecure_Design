import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { ActivatedRoute } from '@angular/router';
import { LightSensor } from 'src/app/models/lightSensor';
import { ShutterSensor } from 'src/app/models/shutterSensor';
import { TempSensor } from 'src/app/models/tempSensor';
import { Modelfactory } from 'src/app/models/modelfactory';
import { Account } from 'src/app/models/account';
import { CustomValidators } from 'src/app/models/custom-validators';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {
  public currentUser?: Account;
  public accounts: Account[] = [];
  public tempSensors: TempSensor[] = [];
  public lightSensors: LightSensor[] = [];
  public shutterSensors: ShutterSensor[] = [];
  private modelFactory = new Modelfactory();
  
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

  constructor(private activatedRoute: ActivatedRoute) {
    this.accounts = this.modelFactory.Accounts;
  }

  public onChangeSensorName(sensorname: string) {
    let newname = (<HTMLInputElement>document.getElementById(sensorname + '-newName')).value;
    console.log(newname)
  }

  private checkUser(id:string) {
    for (let user of this.accounts) {
      if (id == user.id) {
        return user;
      }
    }
    return undefined
  }

  ngOnInit(): void {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    this.currentUser = this.checkUser(id_query);

    let unsigned = document.getElementById('unsignedSettings');
    let devices = document.getElementById('device');
    let adminSettings = document.getElementById('admin-settings');
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

      this.tempSensors = this.modelFactory.getTempSensors(this.currentUser.id);
      this.lightSensors = this.modelFactory.getLightSensors(this.currentUser.id);
      this.shutterSensors = this.modelFactory.getShutterSensors(this.currentUser.id);
      
      for (let acc of this.accounts) {
        if (acc.id == this.currentUser.id) {
          if (acc.role != 'admin') {
            if (adminSettings != null) {
              adminSettings.style.display = 'none';
            }
          }
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