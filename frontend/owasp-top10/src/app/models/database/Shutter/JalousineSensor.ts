import {SmartJalousine} from './SmartJalousine'

export interface JalousineSensor {
    sensor_Id:string,
    name:string,
    status:string,
    state:string,
    actuator_Id:string,
    jal_Id:string,
    smartJalousine: SmartJalousine | null,
}