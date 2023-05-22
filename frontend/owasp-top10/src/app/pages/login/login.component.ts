import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Account } from 'src/app/models/account';
import { HttpAccount } from 'src/app/models/account_DB';
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

  constructor(private router: Router, private http: HttpClient) {
    let modelfactory = new Modelfactory();
    // this.allUsers = modelfactory.Accounts;

    this.GetAccountsFromDB().subscribe((data: Array<HttpAccount>) => {
      this.allUsers = this.ConvertHttpAccounts(data);
      console.log('Users saved in database:', this.allUsers);
    });
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
        // this.router.navigate(['/'], {queryParams: {user: user.id}})
      }
    }

    
    this.usernameFormControl.setErrors({notExist: true})

    // this.router.navigate(['/'], {queryParams: {user: this.allUsers[0].id}})
  }

  public onPostAccount() {
    let newAcc: HttpAccount = {Account_Id: "", Role: "Admin", UserName: "Adminuser", Password: "1Admin"}
    this.http.post('http://localhost:5274/api/account/create', newAcc).subscribe(Response => {
      console.log(Response)
    })
  }

  public onRequestAccounts() {
    this.GetAccountsFromDB().subscribe((data: Array<HttpAccount>) => {
      this.allUsers = this.ConvertHttpAccounts(data);
      console.log('Users saved in database:', this.allUsers);
    });
  }


  private GetAccountsFromDB(): Observable<any> {
    return this.http.get<HttpAccount>('http://localhost:5274/api/account/');
  }

  public DeleteAccount() {
    return this.http.delete('http://localhost:5274/api/account/e0d99e6a-4877-448d-af98-6147b5b8a4fb').subscribe();
  }

  private ConvertHttpAccounts(httpAccounts: HttpAccount[]): Array<Account> {
    let accounts: Account[] = [];

    for (let account of httpAccounts) {
      console.log(account)
      accounts.push({id: account.Account_Id, role: account.Role, username: account.UserName, password: account.Password});
    }
    return accounts;
  }
}

/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}