import { Thermostat } from "./Thermostat";

export interface ThermostatSensor {
    sensor_Id:string,
    name:string,
    status:string,
    temperature:number,
    actuator_Id:string,
    therm_Id:string,
    thermostat:Thermostat | null
}