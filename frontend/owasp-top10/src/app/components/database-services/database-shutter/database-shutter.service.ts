import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, lastValueFrom, of } from 'rxjs';
import { Account } from 'src/app/models/database/Account';
import { Guid } from 'src/app/models/database/GUID';
import { JalousineActuator } from 'src/app/models/database/Shutter/JalousineActuator';
import { JalousineSensor } from 'src/app/models/database/Shutter/JalousineSensor';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';

@Injectable({
  providedIn: 'root'
})
export class DatabaseShutterService {
  private errorUser: Account
  private errorSmartJalousine: SmartJalousine

  constructor(private http: HttpClient) {
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
    this.errorSmartJalousine = {jalousine_Id: Guid, acc_Id: 'error', account: this.errorUser, sensors: [], actuators: []}
  }

  public async GetAll() {
    let smartJalousines = this.GetSmartJalousineFromDB()
    return await lastValueFrom(smartJalousines);
  }

  public async CreateSmartJalousine(newShutter: SmartJalousine) {
    await this.http.post('http://localhost:5274/api/jalousine/create', newShutter).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteSmartJalousine(id: string) {
    await this.http.delete('http://localhost:5274/api/jalousine/delete?id=' + id).subscribe(response => {
          console.log(response)
        })
  }

  public async GetByIDJalousine(id: string) {
    let smartJalousine: SmartJalousine =  await lastValueFrom(this.GetByIDFromDB(id));
    return smartJalousine
  }
  

  public GetSmartJalousineFromDB() {
    return this.http.get<SmartJalousine[]>('http://localhost:5274/api/jalousine/');
  }

  public GetByIDFromDB(id:string) {
    return this.http.get<SmartJalousine>('http://localhost:5274/api/bulb/getById?id='+id).pipe(
      catchError(() => {return of(this.errorSmartJalousine)
    }));
  }

  public async CreateJalousineSensor(jalousineSensor: JalousineSensor) {
    await this.http.post('http://localhost:5274/api/jalousine/sensor/create', jalousineSensor).subscribe(response => {
      console.log(response)
    })
  }

  public async CreateJalousineActuator(jalousineActuator: JalousineActuator) {
    await this.http.post('http://localhost:5274/api/jalousine/actuator/create', jalousineActuator).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteJalousineSensor(id: string) {
    await this.http.delete('http://localhost:5274/api/jalousine/sensor/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteJalousineActuator(id: string) {
    await this.http.delete('http://localhost:5274/api/jalousine/actuator/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }
}
