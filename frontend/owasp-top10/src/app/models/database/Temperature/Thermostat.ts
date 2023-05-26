import { Account } from "../Account";
import { ThermostatActuator } from "./ThermostatActuator";
import { ThermostatSensor } from "./ThermostatSensor";

export interface Thermostat {
    thermostat_Id:string,
    acc_Id:string,
    account: Account | null,
    sensors: ThermostatSensor[],
    actuators: ThermostatActuator[],
}