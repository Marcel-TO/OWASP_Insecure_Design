import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { CustomValidators } from 'src/app/models/custom-validators';
import { Account } from 'src/app/models/database/Account';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.scss']
})
export class SignUpComponent {
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
  isAdminRole = false;

  constructor(private router: Router, private dbService: DatabaseService) {}

  public onChangeRole() {
    this.isAdminRole = !this.isAdminRole;
  }

  public async onSignUp() {
    if (!this.usernameFormControl.valid || !this.passwordFormControl.valid || this.usernameFormControl.value == null || this.passwordFormControl.value == null) {
      return;
    }

    let username: string = this.usernameFormControl.value;
    let password = this.passwordFormControl.value;

    if (this.isAdminRole) {
      await this.dbService.CreateAccount(username, 'admin', password)
    }
    else {
      await this.dbService.CreateAccount(username, 'normal', password)
    }

    this.router.navigate(['/login'], {queryParams: {user: ""}})
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}