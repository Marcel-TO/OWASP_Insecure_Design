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
  private errorUser: Account;
  private errorSmartBulb: SmartBulb;
  private errorSensor: BulbSensor;
  private errorActuator: BulbActuator;

  constructor(private http: HttpClient) {
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
    this.errorSmartBulb = {smartbulb_Id: Guid, acc_Id: 'error', account: this.errorUser, sensors: [], actuators: []}
    this.errorSensor = {sensor_Id:'error', name: 'error', status: 'error', brightness: 0, actuator_Id: 'error', bulb_Id: 'error', smartBulb: null};
    this.errorActuator = {actuator_Id:'error', name:'error', status:'error', target_Brightness:0,sensor_id:'error', bulb_Id:'error',smartBulb:null};
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
    let SmartBulb: SmartBulb =  await lastValueFrom(await this.GetByIDFromDB(id));
    return SmartBulb
  }
  

  public GetSmartBulbsFromDB() {
    return this.http.get<SmartBulb[]>('http://localhost:5274/api/bulb/');
  }

  public async GetByIDFromDB(id:string) {
    return await this.http.get<SmartBulb>('http://localhost:5274/api/bulb/getById?id='+id).pipe(
      catchError(() => {return of(this.errorSmartBulb)
    }));
  }

  public async GetByIDBulbSensor(id:string) {
    return await lastValueFrom(this.http.get<BulbSensor>('http://localhost:5274/api/bulb/sensor/getById?id='+id).pipe(
      catchError(() => {return of(this.errorSensor)
    })));
  }

  public async GetByIDBulbActuator(id:string) {
    return await lastValueFrom(this.http.get<BulbActuator>('http://localhost:5274/api/bulb/actuator/getById?id='+id).pipe(
      catchError(() => {return of(this.errorActuator)
    })));
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

  public async UpdateBulbSensor(bulbsensor: BulbSensor) {
    await this.http.put('http://localhost:5274/api/bulb/sensor/update', bulbsensor).subscribe(response => {
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
