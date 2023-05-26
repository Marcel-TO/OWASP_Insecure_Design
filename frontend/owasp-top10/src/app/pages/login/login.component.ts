import { Component, OnInit } from '@angular/core';
import {FormControl, ReactiveFormsModule, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { CustomValidators } from 'src/app/models/custom-validators';
import { Account } from 'src/app/models/database/Account';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{
  usernameFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(3),
    CustomValidators.patternValidator(/^([^0-9]*)$/, { hasLetters: true}) // Regex expression for everything except numbers
  ]));
  matcher = new MyErrorStateMatcher();
  passwordFormControl = new FormControl('', Validators.compose([
    Validators.required,
    Validators.minLength(4),
    CustomValidators.patternValidator(/\d/, { hasNumber: true }),
    CustomValidators.patternValidator(/[A-Z]/, { hasCapitalCase: true }),
    CustomValidators.patternValidator(/[a-z]/, { hasSmallCase: true })
  ]));
  isHiding = true;
  showDoesNotExist = false;
  currentUser?: Account;
  allUsers: Account[] = [];

  constructor(private router: Router, private dbService: DatabaseService) {
    // let modelfactory = new Modelfactory()
    // this.allUsers = modelfactory.Accounts;
  }
  
  async ngOnInit() {
    let response = await this.dbService.LoginAccount('adminuser', '1Admin');
    this.currentUser = await this.dbService.GetByIDAccount(response);
  }

  public async onLogin() {
    if (!this.usernameFormControl.valid || !this.passwordFormControl.valid || this.allUsers == undefined || this.usernameFormControl.value == null || this.passwordFormControl.value == null) {
      return;
    }

    let username: string = this.usernameFormControl.value;
    let password = this.passwordFormControl.value;

    let response = await this.dbService.LoginAccount(username, password);
    let tempUser = await this.dbService.GetByIDAccount(response);
    if (tempUser.role == 'error') {
      this.usernameFormControl.setErrors({notExist: true});
      return;
    }
    
    this.currentUser = tempUser
    this.router.navigate(['/'], {queryParams: {user: this.currentUser.account_Id}})


    // this.router.navigate(['/'], {queryParams: {user: this.allUsers[0].id}})
  }

  public async onGetAccounts() {
    this.allUsers = await this.dbService.GetAccounts();
    console.log(this.allUsers);
  }

  public onTest() {
    this.dbService.DeleteAccount(this.allUsers[0].account_Id)
  }

  public onCreateAccount() {
    let role = 'admin'
    let username = 'adminuser'
    let password = '1Admin'
    this.dbService.CreateAccount(role,username,password);
  }

  public async onCreateDevice() {
    if (this.currentUser != null) {
      // await this.dbService.CreateSmartBulb(this.currentUser.account_Id);
      await this.dbService.CreateSmartJalousine(this.currentUser.account_Id);
      await this.dbService.CreateThermostat(this.currentUser.account_Id);
    }
  }

  public async onGetDevices() {
    if (this.currentUser != null) {
      let result = await this.dbService.GetAllDevicesFromAccount(this.currentUser.account_Id)
      console.log(this.currentUser.account_Id)
      console.log(result)
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