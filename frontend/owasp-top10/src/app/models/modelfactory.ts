import { Account } from "./account";
import { TempSensor } from "./tempSensor";
import { LightSensor } from "./lightSensor";
import { ShutterSensor } from "./shutterSensor";

export class Modelfactory {
    public Accounts = this.getAccounts();
    public TempSensors = this.getAllTempSensors();
    public LightSensors = this.getAllLightSensors();
    public ShutterSensors = this.getAllShutterSensors();

    public getTempSensors(id: string) {
        let result: TempSensor[] = []
        for (let sensor of this.TempSensors) {
            if (id == sensor.account_id) {
                result.push(sensor);
            }
        }
        return result;
    }

    public getLightSensors(id: string) {
        let result: LightSensor[] = []
        for (let sensor of this.LightSensors) {
            if (id == sensor.account_id) {
                result.push(sensor);
            }
        }
        return result;
    }

    public getShutterSensors(id: string) {
        let result: ShutterSensor[] = []
        for (let sensor of this.ShutterSensors) {
            if (id == sensor.account_id) {
                result.push(sensor);
            }
        }
        return result;
    }

    private getAccounts(): Account[] {
        return [{id: '007admin700', role: 'admin', username: 'adminuser', password: '1Admin'},
        {id: '008normal800', role: 'user', username: 'normaluser', password: '1Normal'}];
    }

    private getAllTempSensors(): TempSensor[] {
        return [{id: '001', name: 'Temp-Livingroom', temp: 24, status: 'on', account_id: '007admin700'},
    {id: '002', name: 'Temp-Bedroom', temp: 18, status: 'on', account_id: '007admin700'},
    {id: '003', name: 'Temp-Kitchen', temp: 26, status: 'on', account_id: '007admin700'},
    {id: '004', name: 'Temp-Bathroom', temp: 25, status: 'on', account_id: '007admin700'},
    {id: '001', name: 'Normal-Livingroom', temp: 24, status: 'on', account_id: '008normal800'},
    {id: '002', name: 'Normal-Bedroom', temp: 18, status: 'on', account_id: '008normal800'},];
    }

    private getAllLightSensors(): LightSensor[] {
        return [{id: '001', name: 'Light_Livingroom', brightness: 4, warmness: 6, account_id: '007admin700'},
    {id: '002', name: 'Light_Kitchen', brightness: 8, warmness: 3, account_id: '007admin700'},
    {id: '003', name: 'Light_Bedroom', brightness: 4, warmness: 6, account_id: '007admin700'},
    {id: '004', name: 'Light_Upstairs', brightness: 0, warmness: 0, account_id: '007admin700'},
    {id: '001', name: 'Normal_Livingroom', brightness: 4, warmness: 6, account_id: '008normal800'},
    {id: '002', name: 'Normal_Kitchen', brightness: 8, warmness: 3, account_id: '008normal800'},];
    }

    private getAllShutterSensors(): ShutterSensor[] {
        return [{id: '001', name: 'Shutter Livingroom', isOpen: true, account_id: '007admin700'},
    {id: '002', name: 'Shutter Kitchen', isOpen: false, account_id: '007admin700'},
    {id: '003', name: 'Shutter Bedroom', isOpen: true, account_id: '007admin700'},
    {id: '004', name: 'Shutter Terrace', isOpen: false, account_id: '007admin700'},
    {id: '001', name: 'Shutter Normal', isOpen: true, account_id: '008normal800'},];
    }
}