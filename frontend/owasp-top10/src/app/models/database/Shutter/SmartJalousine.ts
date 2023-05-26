import { Account } from "../Account";
import { JalousineActuator } from "./JalousineActuator";
import { JalousineSensor } from "./JalousineSensor";

export interface SmartJalousine {
    jalousine_Id:string,
    acc_Id:string,
    account: Account | null,
    sensors: JalousineSensor[]
    actuators: JalousineActuator[]
}