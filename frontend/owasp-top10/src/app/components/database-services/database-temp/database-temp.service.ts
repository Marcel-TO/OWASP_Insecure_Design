import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, lastValueFrom, of } from 'rxjs';
import { Guid } from 'src/app/models/database/GUID';
import { Account } from 'src/app/models/database/Account';
import { Thermostat } from 'src/app/models/database/Temperature/Thermostat';
import { ThermostatActuator } from 'src/app/models/database/Temperature/ThermostatActuator';
import { ThermostatSensor } from 'src/app/models/database/Temperature/ThermostatSensor';

@Injectable({
  providedIn: 'root'
})
export class DatabaseTempService {
  private errorUser: Account
  private errorThermostat: Thermostat

  constructor(private http: HttpClient) { 
    this.errorUser = {account_Id: 'error', role: 'error', userName: 'error', password: 'error'}
    this.errorThermostat = {thermostat_Id: Guid, acc_Id: 'error', account: this.errorUser, sensors: [], actuators: []}
  }

  public async GetAll() {
    let thermostats$ = this.GetThermostatsFromDB()
    return await lastValueFrom(thermostats$);
  }

  public async CreateThermostat(newTemp: Thermostat) {
    await this.http.post('http://localhost:5274/api/thermostat/create', newTemp).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteThermostat(id: string) {
    await this.http.delete('http://localhost:5274/api/thermostat/delete?id=' + id).subscribe(response => {
          console.log(response)
        })
  }

  public async GetByIDThermostat(id: string) {
    let SmartBulb: Thermostat =  await lastValueFrom(this.GetByIDFromDB(id));
    return SmartBulb
  }
  

  public GetThermostatsFromDB() {
    return this.http.get<Thermostat[]>('http://localhost:5274/api/thermostat');
  }

  public GetByIDFromDB(id:string) {
    return this.http.get<Thermostat>('http://localhost:5274/api/thermostat/getById?id='+id).pipe(
      catchError(() => {return of(this.errorThermostat)
    }));
  }

  public async CreateThermostatSensor(tempsensor: ThermostatSensor) {
    await this.http.post('http://localhost:5274/api/thermostat/sensor/create', tempsensor).subscribe(response => {
      console.log(response)
    })
  }

  public async CreateThermostatActuator(tempactuator: ThermostatActuator) {
    await this.http.post('http://localhost:5274/api/thermostat/actuator/create', tempactuator).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteThermostatSensor(id: string) {
    await this.http.delete('http://localhost:5274/api/thermostat/sensor/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }

  public async DeleteThermostatActuator(id: string) {
    await this.http.delete('http://localhost:5274/api/thermostat/actuator/delete?id=' + id).subscribe(response => {
      console.log(response)
    })
  }
}
