import { Component, OnInit } from '@angular/core';
import {FormControl, ReactiveFormsModule, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Account } from 'src/app/models/account';
import { CustomValidators } from 'src/app/models/custom-validators';
import { Modelfactory } from 'src/app/models/modelfactory';

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
  currentUser: Account | undefined = undefined;
  allUsers: Account[] = [];

  constructor(private router: Router) {
    let modelfactory = new Modelfactory()
    this.allUsers = modelfactory.Accounts;
  }
  
  ngOnInit(): void {
  }

  public onLogin() {
    if (!this.usernameFormControl.valid || !this.passwordFormControl.valid || this.allUsers == undefined) {
      return;
    }

    let username = this.usernameFormControl.value;
    let password = this.passwordFormControl.value;

    for (let user of this.allUsers) {
      if (username == user.username && password == user.password) {
        this.currentUser = user;
        this.router.navigate(['/'], {queryParams: {user: user.id}})
      }
    }

    this.usernameFormControl.setErrors({notExist: true})

    // this.router.navigate(['/'], {queryParams: {user: this.allUsers[0].id}})
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}