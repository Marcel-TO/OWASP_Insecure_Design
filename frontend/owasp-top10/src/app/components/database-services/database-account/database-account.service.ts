import { NgIfContext } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { response } from 'express';
import { Observable, catchError, firstValueFrom, lastValueFrom, map, of, tap, throwError } from 'rxjs';
import { Account } from 'src/app/models/account';
import { HttpAccount } from 'src/app/models/database/HttpAccount';

@Injectable({
  providedIn: 'root'
})
export class DatabaseAccountService {
  public users: Account[] = [];
  private errorUser: HttpAccount;

  constructor(private http: HttpClient) { 
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
  }

  public async GetAll() {
    let users$;
    let users: HttpAccount[] = [];
    users$ = this.GetAccountsFromDB()
    users = await lastValueFrom(users$);
    return this.ConvertHttpAccounts(users)
  }

  public async Create(newUser: Account) {
    await this.http.post('http://localhost:5274/api/account/create', newUser).subscribe(response => {
      console.log(response)
    })
  }

  public async Delete(id: string) {
    let users: HttpAccount[] = await lastValueFrom(this.GetAccountsFromDB());
    for (let user of users) {
      if (user.account_Id == id) {
        await this.http.delete('http://localhost:5274/api/account/delete?id=' + id).subscribe(response => {
          console.log(response)
        })
      }
    }
  }

  public async Login(username: string, password: string) {
    return await lastValueFrom(this.LoginAccountRequest(username, password))
  }

  public async GetByID(id: string) {
    let user: HttpAccount =  await lastValueFrom(this.GetByIDFromDB(id));
    return this.ConvertSingleHttpAccount(user);
  }
  

  private GetAccountsFromDB() {
    return this.http.get<HttpAccount[]>('http://localhost:5274/api/account/');
  }

  private LoginAccountRequest(username: string, password: string) {
    return this.http.post('http://localhost:5274/api/account/login', {'userName': username, 'password': password}).pipe(
      catchError((error: Error) => {
        return error.message
      })
    );
  }

  private GetByIDFromDB(id:string) {
    console.log("Id that gets queried: " + id);
    return this.http.get<HttpAccount>('http://localhost:5274/api/account/getById?id='+id).pipe(
      catchError(() => {return of(this.errorUser)
    }));
  }

  private ConvertHttpAccounts(httpAccounts: HttpAccount[]): Account[] {
    let accounts: Account[] = [];

    for (let account of httpAccounts) {
      accounts.push({id: account.account_Id, role: account.role, username: account.userName, password: account.password});
    }
    return accounts;
  }

  private ConvertSingleHttpAccount(httpAccount: HttpAccount): Account {
    let account: Account = {id: httpAccount.account_Id, role: httpAccount.role, username: httpAccount.userName, password: httpAccount.password};
    return account;
  }
}

