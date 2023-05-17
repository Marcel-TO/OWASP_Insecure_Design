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
  currentUser: Account | undefined = undefined;
  allUsers?: Account[]

  constructor(private router: Router) {
    let modelfactory = new Modelfactory()
    this.allUsers = modelfactory.Accounts;
  }
  
  ngOnInit(): void {
    if (this.allUsers != null) {
      this.currentUser = this.allUsers[0]
    }
  }

  public onClick() {
    // console.log("inside login: " + this.currentUser?.username)
    // this.router.navigate(['/'], {state: this.currentUser});
    this.router.navigate(['/'], {queryParams: {username: this.currentUser?.username}})
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}