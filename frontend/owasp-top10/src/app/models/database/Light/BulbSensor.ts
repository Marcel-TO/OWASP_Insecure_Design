import { SmartBulb } from "./SmartBulb";

export interface BulbSensor {
    sensor_Id:string,
    name: string,
    status:string,
    brightness:number,
    actuator_Id:string,
    bulb_Id:string,
    smartBulb:SmartBulb | null
}