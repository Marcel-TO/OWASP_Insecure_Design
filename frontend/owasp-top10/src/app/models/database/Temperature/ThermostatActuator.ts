import { Thermostat } from "./Thermostat";

export interface ThermostatActuator {
    actuator_Id:string,
    name:string,
    status:string,
    target_Temperature:number,
    sensor_Id:string,
    therm_Id:string,
    thermostat:Thermostat | null,
}