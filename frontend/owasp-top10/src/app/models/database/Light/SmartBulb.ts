import { Account } from "../Account";
import { BulbActuator } from "./BulbActuator";
import { BulbSensor } from "./BulbSensor";

export interface SmartBulb {
    smartbulb_Id:string,
    acc_Id:string,
    account: Account | null,
    sensors:BulbSensor[],
    actuators:BulbActuator[],
}