import { SmartBulb } from "./Light/SmartBulb";
import { SmartJalousine } from "./Shutter/SmartJalousine";
import { Thermostat } from "./Temperature/Thermostat";

export interface SmartDevices {
    thermostats: Thermostat[],
    smartBulbs: SmartBulb[],
    smartJalousines: SmartJalousine[],
}