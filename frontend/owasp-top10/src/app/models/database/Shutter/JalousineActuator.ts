import { SmartJalousine } from "./SmartJalousine";

export interface JalousineActuator {
    actuator_Id:string,
    name:string,
    status:string,
    target_State:string,
    sensor_Id:string,
    jal_Id:string,
    smartJalousine:SmartJalousine | null,
}