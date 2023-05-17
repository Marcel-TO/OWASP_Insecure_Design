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
  public currentUser?: string;
  public accounts?: Account[];
  public tempSensors?: TempSensor[];
  public lightSensors?: LightSensor[];
  public shutterSensors?: ShutterSensor[];
  
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
    let modelFactory = new Modelfactory();
    this.accounts = modelFactory.Accounts;
    this.tempSensors = modelFactory.TempSensors;
    this.lightSensors = modelFactory.LightSensors;
    this.shutterSensors = modelFactory.ShutterSensors;
  }

  public onChangeSensorName(sensorname: string) {
    let newname = (<HTMLInputElement>document.getElementById(sensorname + '-newName')).value;
    console.log(newname)
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
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
      if (this.accounts != null) {
        if (unsigned != null) {
          unsigned.style.display = 'none'
        }

        for (let acc of this.accounts) {
          if (acc.username == this.currentUser) {
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
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}