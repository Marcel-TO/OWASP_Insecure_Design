import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from 'src/app/models/account';
import { HttpAccount } from 'src/app/models/database/HttpAccount';
import { DatabaseAccountService } from './database-account/database-account.service';
import { DatabaseTempService } from './database-temp/database-temp.service';
import { DatabaseLightService } from './database-light/database-light.service';
import { DatabaseShutterService } from './database-shutter/database-shutter.service';

@Injectable({
  providedIn: 'root',
})
export class DatabaseService {
  constructor(
    private http: HttpClient,
    private account: DatabaseAccountService,
    private temp: DatabaseTempService,
    private light: DatabaseLightService,
    private shutter: DatabaseShutterService
  ) {}

  public async GetAccounts(): Promise<Account[]> {
    return await this.account.GetAll();
  }

  public async CreateAccount(newUser: Account) {
    await this.account.Create(newUser);
  }

  public async DeleteAccount(id: string) {
    await this.account.Delete(id);
  }

  public async LoginAccount(username:string, password: string): Promise<string> {
    let response = await this.account.Login(username, password);
    return response.toString()
  }

  public async GetByIDAccount(id:string) {
    return await this.account.GetByID(id);
  }
}
