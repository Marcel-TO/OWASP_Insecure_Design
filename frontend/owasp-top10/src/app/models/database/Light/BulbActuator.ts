import { SmartBulb } from "./SmartBulb";

export interface BulbActuator {
    actuator_Id:string,
    name:string,
    status:string,
    target_Brightness:number,
    sensor_id:string,
    bulb_Id:string,
    smartBulb:SmartBulb | null,
}