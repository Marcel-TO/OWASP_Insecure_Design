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
import { DatabaseLoggerService } from './database-logger/database-logger.service';
import { BulbSensor } from 'src/app/models/database/Light/BulbSensor';
import { BulbActuator } from 'src/app/models/database/Light/BulbActuator';
import { JalousineSensor } from 'src/app/models/database/Shutter/JalousineSensor';
import { JalousineActuator } from 'src/app/models/database/Shutter/JalousineActuator';
import { ThermostatSensor } from 'src/app/models/database/Temperature/ThermostatSensor';
import { ThermostatActuator } from 'src/app/models/database/Temperature/ThermostatActuator';

@Injectable({
  providedIn: 'root',
})
export class DatabaseService {
  constructor(
    private http: HttpClient,
    private account: DatabaseAccountService,
    private temp: DatabaseTempService,
    private light: DatabaseLightService,
    private shutter: DatabaseShutterService,
    private logger: DatabaseLoggerService
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

  public async UpdateAccount(id:string,username: string, role:string,password:string) {
    await this.account.Update({account_Id: id, role: role, userName: username, password: password});
  }

  public async DeleteAccount(id: string) {
    await this.account.Delete(id);
  }

  public async LoginAccount(username:string, password: string): Promise<string> {
    let response = await this.account.Login(username, password);
    console.log(response)
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
    let smartBulb: SmartBulb = {smartbulb_Id: Guid, acc_Id: acc_id, account: null, sensors: [], actuators: []}
    await this.light.CreateSmartBulb(smartBulb)
    await this.CreateLoggedData("Created a Smart Lightbulb for the user with the user id: "+acc_id, acc_id);
  }

  public async CreateBulbSensor(name:string, brightness:number, bulb_id:string) {
    let bulbSensor: BulbSensor = {sensor_Id: Guid, name: name, status: "online", brightness: brightness, actuator_Id: Guid, bulb_Id: bulb_id, smartBulb: null};
    await this.light.CreateBulbSensor(bulbSensor)

    let smartBulb: SmartBulb = await this.light.GetByID(bulb_id);
    await this.CreateLoggedData("Created a sensor for the Smart Lightbulb with the id:" + smartBulb.smartbulb_Id, smartBulb.acc_Id);
  }

  public async CreateBulbActuator(name:string, brightness:number, bulb_id:string) {
    let bulbActuator: BulbActuator = {actuator_Id: Guid, name: name, status: "online", target_Brightness: brightness, sensor_id: Guid, bulb_Id: bulb_id, smartBulb:null};
    await this.light.CreateBulbActuator(bulbActuator)

    let smartBulb: SmartBulb = await this.light.GetByID(bulb_id);
    await this.CreateLoggedData("Created an actuator for the Smart Lightbulb with the id:" + smartBulb.smartbulb_Id, smartBulb.acc_Id);
  }

  public async UpdateBulbSensor(id:string,name:string, brightness:number, bulb_id:string) {
    let bulbSensor: BulbSensor = {sensor_Id: id, name: name, status: "online", brightness: brightness, actuator_Id: Guid, bulb_Id: bulb_id, smartBulb: null};
    await this.light.UpdateBulbSensor(bulbSensor)

    let smartBulb: SmartBulb = await this.light.GetByID(bulb_id);
    await this.CreateLoggedData("Updated the sensor with the id: "+id+" for the Smart Lightbulb with the id: "+bulb_id, smartBulb.acc_Id);
  }

  public async DeleteSmartBulb(id:string) {
    let smartBulb: SmartBulb = await this.light.GetByID(id);
    await this.light.Delete(id);
    await this.CreateLoggedData("Deleted the Smart Lightbulb with the id: " + id,smartBulb.acc_Id);
  }

  public async DeleteBulbSensor(id:string) {
    let sensor: BulbSensor = await this.light.GetByIDBulbSensor(id);
    let smartBulb: SmartBulb = await this.light.GetByID(sensor.bulb_Id);
    await this.light.DeleteBulbSensor(id)
    await this.logger.Create('Deleted sensor with the id: '+id+' from the Smart Lightbulb with the id: '+smartBulb.smartbulb_Id, smartBulb.acc_Id);
  }

  public async DeleteBulbActuator(id:string) {
    let actuator: BulbActuator = await this.light.GetByIDBulbActuator(id);
    let smartBulb: SmartBulb = await this.light.GetByID(actuator.bulb_Id);
    await this.light.DeleteBulbSensor(id)
    await this.logger.Create('Deleted actuator with the id: '+id+' from the Smart Lightbulb with the id: '+smartBulb.smartbulb_Id, smartBulb.acc_Id);
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
    await this.CreateLoggedData("Created a Smart Jalousine for the user with the user id: " + acc_id, acc_id);
  }

  public async CreateJalousineSensor(name:string, state:boolean, shutter_id:string) {
    let sensor: JalousineSensor = {sensor_Id: Guid, name: name, status: "online", state: String(state), actuator_Id: Guid, jal_Id: shutter_id, smartJalousine: null};
    await this.shutter.CreateJalousineSensor(sensor)

    let smartJalousine = await this.shutter.GetByIDJalousine(shutter_id);
    await this.CreateLoggedData("Created a sensor for the Smart Jalousine with the id: "+shutter_id, smartJalousine.acc_Id);
  }

  public async CreateJalousineActuator(name:string, state:boolean, shutter_id:string) {
    let actuator: JalousineActuator = {actuator_Id: Guid, name: name, status: "online", target_State: String(state), sensor_Id: Guid, jal_Id: shutter_id, smartJalousine:null};
    await this.shutter.CreateJalousineActuator(actuator);

    let smartJalousine = await this.shutter.GetByIDJalousine(shutter_id);
    await this.CreateLoggedData("Created an actuator for the Smart Jalousine with the id: "+shutter_id, smartJalousine.acc_Id);
  }

  public async UpdateJalousineSensor(id:string,name:string,state:string,shutter_id:string) {
    let sensor: JalousineSensor = {sensor_Id: id, name: name, status: "online", state: String(state), actuator_Id: Guid, jal_Id: shutter_id, smartJalousine: null};
    await this.shutter.UpdateJalousineSensor(sensor)

    let smartJalousine = await this.shutter.GetByIDJalousine(shutter_id);
    await this.CreateLoggedData("Updated the sensor with the id: "+id+" for the Smart Jalousine with the id: "+shutter_id, smartJalousine.acc_Id);
  }

  public async DeleteSmartJalousine(id:string) {
    let smartJalousine: SmartJalousine = await this.shutter.GetByIDJalousine(id);
    await this.shutter.DeleteSmartJalousine(id);
    await this.CreateLoggedData("Deleted the Smart Jalousine with the id: " + id,smartJalousine.acc_Id)
  }

  public async DeleteJalousineSensor(id:string) {
    let sensor: JalousineSensor = await this.shutter.GetByIDJalousineSensor(id);
    let smartJalousine: SmartJalousine = await this.shutter.GetByIDJalousine(sensor.jal_Id);
    await this.shutter.DeleteJalousineSensor(id)
    await this.logger.Create('Deleted sensor with the id: '+id+' from the Smart Jalousine with the id: '+smartJalousine.jalousine_Id, smartJalousine.acc_Id);
  }

  public async DeleteJalousineActuator(id:string) {
    let actuator: JalousineActuator = await this.shutter.GetByIDJalousineActuator(id);
    let smartJalousine: SmartJalousine = await this.shutter.GetByIDJalousine(actuator.jal_Id);
    await this.shutter.DeleteJalousineActuator(id)
    await this.logger.Create('Deleted actuator with the id: '+id+' from the Smart Jalousine with the id: '+smartJalousine.jalousine_Id, smartJalousine.acc_Id);
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
    let thermostat: Thermostat = {thermostat_Id: Guid, acc_Id: acc_id, account: null, sensors: [], actuators: []};
    await this.temp.CreateThermostat(thermostat)
    await this.CreateLoggedData("Created a Smart Thermostat for the user with the user id: "+acc_id, acc_id);
  }

  public async CreateThermostatSensor(name:string, temp:number, therm_id:string) {
    let sensor: ThermostatSensor = {sensor_Id: Guid, name: name, status: "online", temperature: temp, actuator_Id: Guid, therm_Id: therm_id, thermostat: null}
    await this.temp.CreateThermostatSensor(sensor)

    let smartThermostat = await this.temp.GetByIDThermostat(therm_id);
    await this.CreateLoggedData("Created a sensor for the Smart Thermostat with the id: "+therm_id, smartThermostat.acc_Id);
  }

  public async CreateThermostatActuator(name:string, temp:number, therm_id:string) {
    await this.temp.CreateThermostatActuator({actuator_Id: Guid, name: name, status: "online", target_Temperature: temp, sensor_Id: Guid, therm_Id: therm_id, thermostat:null})

    let smartThermostat = await this.temp.GetByIDThermostat(therm_id);
    await this.CreateLoggedData("Created an actuator for the Smart Thermostat with the id: "+therm_id, smartThermostat.acc_Id);
  }

  public async DeleteThermostat(id:string) {
    let smartThermostat = await this.temp.GetByIDThermostat(id);
    await this.temp.DeleteThermostat(id);
    await this.CreateLoggedData("Deleted the Smart Jalousine with the id: " + id,smartThermostat.acc_Id)
  }

  public async DeleteThermostatSensor(id:string) {
    let sensor: ThermostatSensor = await this.temp.GetByIDThermostatSensor(id);
    let smartThermostat: Thermostat = await this.temp.GetByIDThermostat(sensor.therm_Id);
    await this.temp.DeleteThermostatSensor(id)
    await this.logger.Create('Deleted sensor with the id: '+id+' from the Smart Thermostat with the id: '+smartThermostat.thermostat_Id, smartThermostat.acc_Id);
  }

  public async DeleteThermostatActuator(id:string) {
    let actuator: ThermostatActuator = await this.temp.GetByIDThermostatActuator(id);
    let smartThermostat: Thermostat = await this.temp.GetByIDThermostat(actuator.therm_Id);
    await this.temp.DeleteThermostatSensor(id)
    await this.logger.Create('Deleted actuator with the id: '+id+' from the Smart Thermostat with the id: '+smartThermostat.thermostat_Id, smartThermostat.acc_Id);
  }

  public async UpdateThermostatSensor(id:string,name:string,temp:number,therm_id:string) {
    let sensor: ThermostatSensor = {sensor_Id: id, name: name, status: "online", temperature: temp, actuator_Id: Guid, therm_Id: therm_id, thermostat: null}
    await this.temp.UpdateThermostatSensor(sensor)

    let smartThermostat = await this.temp.GetByIDThermostat(therm_id);
    await this.CreateLoggedData("Updated the sensor with the id: "+id+" for the Smart Thermostat with the id: "+therm_id, smartThermostat.acc_Id);
  }

  public async GetByIdThermostat(id:string) {
    return await this.temp.GetByIDThermostat(id);
  }

  public async GettAllThermostatsFromAccount(acc_id:string): Promise<Thermostat[]> {
    let result = await this.GetAllDevicesFromAccount(acc_id);
    return result.thermostats;
  }

  /*
  * Log History
  */
  public async GetAllLoggedData() {
    return await this.logger.GetAll();
  }

  public async GetByIdLoggedData(id:string) {
    return await this.logger.GetById(id);
  }

  public async GetByAccountIdLoggedData(acc_id:string) {
    return await this.logger.GetByAccountId(acc_id);
  }

  public async CreateLoggedData(data:string, acc_id:string) {
    await this.logger.Create(data, acc_id);
  }

  public async DeleteLoggedData(id:string) {
    await this.logger.Delete(id);
  }
}
