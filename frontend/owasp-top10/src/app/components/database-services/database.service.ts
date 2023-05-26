import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, lastValueFrom } from 'rxjs';
import { Account } from 'src/app/models/database/Account';
import { DatabaseAccountService } from './database-account/database-account.service';
import { DatabaseTempService } from './database-temp/database-temp.service';
import { DatabaseLightService } from './database-light/database-light.service';
import { DatabaseShutterService } from './database-shutter/database-shutter.service';
import { SmartBulb } from 'src/app/models/database/Light/SmartBulb';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';
import { Thermostat } from 'src/app/models/database/Temperature/Thermostat';
import { Guid } from 'src/app/models/database/GUID';
import { SmartDevices } from 'src/app/models/database/SmartDevices';

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

  /*
  * Account
  */
  public async GetAccounts(): Promise<Account[]> {
    return await this.account.GetAll();
  }

  public async CreateAccount(username: string, role:string,password:string) {
    await this.account.Create({account_Id: '00000000-0000-0000-0000-000000000000', role: role, userName: username, password: password});
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

  public async GetAllDevicesFromAccount(id:string): Promise<SmartDevices> {
    let result = await lastValueFrom(this.http.get<SmartDevices>('http://localhost:5274/api/devices/byUserId/getById?id='+id))
    return result
  }


  /*
  * Smart Bulbs
  */
  public async CreateSmartBulb(acc_id: string) {
    await this.light.CreateSmartBulb({smartbulb_Id: Guid, acc_Id: acc_id, account: null, sensors: [], actuators: []})
  }

  public async CreateBulbSensor(name:string, brightness:number, bulb_id:string) {
    await this.light.CreateBulbSensor({sensor_Id: Guid, name: name, status: "online", brightness: brightness, actuator_Id: Guid, bulb_Id: bulb_id, smartBulb: null})
  }

  public async CreateBulbActuator(name:string, brightness:number, bulb_id:string) {
    await this.light.CreateBulbActuator({actuator_Id: Guid, name: name, status: "online", target_Brightness: brightness, sensor_id: Guid, bulb_Id: bulb_id, smartBulb:null})
  }

  public async DeleteSmartBulb(id:string) {
    await this.light.Delete(id);
  }

  public async GetByIdSmartBulb(id:string) {
    return await this.light.GetByID(id);
  }

  public async GettAllSmartBulbsFromAccount(acc_id:string): Promise<SmartBulb[]> {
    let result = await this.GetAllDevicesFromAccount(acc_id);
    return result.smartBulbs;
  }

  /*
  * Smart Jalousine
  */
  public async CreateSmartJalousine(acc_id: string) {
    await this.shutter.CreateSmartJalousine({jalousine_Id: Guid, acc_Id: acc_id, account: null, sensors: [], actuators: []})
  }

  public async CreateJalousineSensor(name:string, state:boolean, bulb_id:string) {
    await this.shutter.CreateJalousineSensor({sensor_Id: Guid, name: name, status: "online", state: String(state), actuator_Id: Guid, jal_Id: bulb_id, smartJalousine: null})
  }

  public async CreateJalousineActuator(name:string, state:boolean, bulb_id:string) {
    await this.shutter.CreateJalousineActuator({actuator_Id: Guid, name: name, status: "online", target_State: String(state), sensor_Id: Guid, jal_Id: bulb_id, smartJalousine:null})
  }

  public async DeleteSmartJalousine(id:string) {
    await this.shutter.DeleteSmartJalousine(id);
  }

  public async GetByIdSmartJalousine(id:string) {
    return await this.shutter.GetByIDJalousine(id);
  }

  public async GettAllSmartJalousinesFromAccount(acc_id:string): Promise<SmartJalousine[]> {
    let result = await this.GetAllDevicesFromAccount(acc_id);
    return result.smartJalousines;
  }

  /*
  * Thermostat
  */
  public async CreateThermostat(acc_id: string) {
    await this.temp.CreateThermostat({thermostat_Id: Guid, acc_Id: acc_id, account: null, sensors: [], actuators: []})
  }

  public async CreateThermostatSensor(name:string, temp:number, therm_id:string) {
    await this.temp.CreateThermostatSensor({sensor_id: Guid, name: name, status: "online", temperature: temp, actuator_Id: Guid, therm_Id: therm_id, thermostat: null})
  }

  public async CreateThermostatActuator(name:string, temp:number, therm_id:string) {
    await this.temp.CreateThermostatActuator({actuator_Id: Guid, name: name, status: "online", target_Temperature: temp, sensor_Id: Guid, therm_Id: therm_id, thermostat:null})
  }

  public async DeleteThermostat(id:string) {
    await this.temp.DeleteThermostat(id);
  }

  public async GetByIdThermostat(id:string) {
    return await this.temp.GetByIDThermostat(id);
  }

  public async GettAllThermostatsFromAccount(acc_id:string): Promise<Thermostat[]> {
    let result = await this.GetAllDevicesFromAccount(acc_id);
    return result.thermostats;
  }
}
