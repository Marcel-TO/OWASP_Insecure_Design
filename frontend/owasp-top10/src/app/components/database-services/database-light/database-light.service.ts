import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, lastValueFrom, of } from 'rxjs';
import { Account } from 'src/app/models/database/Account';
import { Guid } from 'src/app/models/database/GUID';
import { BulbActuator } from 'src/app/models/database/Light/BulbActuator';
import { BulbSensor } from 'src/app/models/database/Light/BulbSensor';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';

@Injectable({
  providedIn: 'root'
})
export class DatabaseLightService {
  private errorUser: Account
  private errorSmartBulb: SmartBulb

  constructor(private http: HttpClient) {
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
    this.errorSmartBulb = {smartbulb_Id: Guid, acc_Id: 'error', account: this.errorUser, sensors: [], actuators: []}
  }

  public async GetAll() {
    let SmartBulbs$ = this.GetSmartBulbsFromDB()
    return await lastValueFrom(SmartBulbs$);
  }

  public async CreateSmartBulb(newBulb: SmartBulb) {
    await this.http.post('http://localhost:5274/api/bulb/create', newBulb).subscribe(response => {
      console.log(response)
    })
  }

  public async Delete(id: string) {
    await this.http.delete('http://localhost:5274/api/bulb/delete?id=' + id).subscribe(response => {
          console.log(response)
        })
  }

  public async GetByID(id: string) {
    let SmartBulb: SmartBulb =  await lastValueFrom(this.GetByIDFromDB(id));
    return SmartBulb
  }
  

  public GetSmartBulbsFromDB() {
    return this.http.get<SmartBulb[]>('http://localhost:5274/api/bulb/');
  }

  public GetByIDFromDB(id:string) {
    return this.http.get<SmartBulb>('http://localhost:5274/api/bulb/getById?id='+id).pipe(
      catchError(() => {return of(this.errorSmartBulb)
    }));
  }

  public async CreateBulbSensor(bulbsensor: BulbSensor) {
    await this.http.post('http://localhost:5274/api/bulb/sensor/create', bulbsensor).subscribe(response => {
      console.log(response)
    })
  }

  public async CreateBulbActuator(bulbsensor: BulbActuator) {
    await this.http.post('http://localhost:5274/api/bulb/actuator/create', bulbsensor).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteBulbSensor(id: string) {
    await this.http.delete('http://localhost:5274/api/bulb/sensor/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteBulbActuator(id: string) {
    await this.http.delete('http://localhost:5274/api/bulb/actuator/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }
}
