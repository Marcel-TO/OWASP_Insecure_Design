import { NgIfContext } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { response } from 'express';
import { Observable, catchError, firstValueFrom, lastValueFrom, map, of, tap, throwError } from 'rxjs';
import { Account } from 'src/app/models/database/Account';

@Injectable({
  providedIn: 'root'
})
export class DatabaseAccountService {
  private errorUser: Account;

  constructor(private http: HttpClient) { 
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
  }

  public async GetAll() {
    let users$;
    let users: Account[] = [];
    users$ = this.GetAccountsFromDB()
    return await lastValueFrom(users$);
  }

  public async Create(newUser: Account) {
    await this.http.post('http://localhost:5274/api/account/create', newUser).subscribe(response => {
      console.log(response)
    })
  }

  public async Delete(id: string) {
    let users: Account[] = await lastValueFrom(this.GetAccountsFromDB());
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
    let user: Account =  await lastValueFrom(this.GetByIDFromDB(id));
    return user;
  }
  

  private GetAccountsFromDB() {
    return this.http.get<Account[]>('http://localhost:5274/api/account/');
  }

  private LoginAccountRequest(username: string, password: string) {
    return this.http.post('http://localhost:5274/api/account/login', {'userName': username, 'password': password}).pipe(
      catchError((error: Error) => {
        return error.message
      })
    );
  }

  private GetByIDFromDB(id:string) {
    return this.http.get<Account>('http://localhost:5274/api/account/getById?id='+id).pipe(
      catchError(() => {return of(this.errorUser)
    }));
  }
}

