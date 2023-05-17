import { Account } from "./account";
import { TempSensor } from "./tempSensor";
import { LightSensor } from "./lightSensor";
import { ShutterSensor } from "./shutterSensor";

export class Modelfactory {
    public Accounts?: Account[];
    public TempSensors?: TempSensor[];
    public LightSensors?: LightSensor[];
    public ShutterSensors?: ShutterSensor[];

    constructor() {
        this.Accounts = this.getAccounts();
        this.TempSensors = this.getTempSensors();
        this.LightSensors = this.getLightSensors();
        this.ShutterSensors = this.getShutterSensors();
    }

    private getAccounts(): Account[] {
        return [{id: '007', role: 'admin', username: 'admin', password: '1Admin'},
        {id: '008', role: 'user', username: 'normaluser', password: '1Normal'}];
    }

    private getTempSensors(): TempSensor[] {
        return [{id: '001', name: 'Temp-Livingroom', temp: 24, status: 'on', account_id: 'testuser'},
    {id: '002', name: 'Temp-Bedroom', temp: 18, status: 'on', account_id: 'testuser'},
    {id: '003', name: 'Temp-Kitchen', temp: 26, status: 'on', account_id: 'testuser'},
    {id: '004', name: 'Temp-Bathroom', temp: 25, status: 'on', account_id: 'testuser'}];
    }

    private getLightSensors(): LightSensor[] {
        return [{id: '001', name: 'Light_Livingroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '002', name: 'Light_Kitchen', brightness: 8, warmness: 3, account_id: 'testuser'},
    {id: '003', name: 'Light_Bedroom', brightness: 4, warmness: 6, account_id: 'testuser'},
    {id: '004', name: 'Light_Upstairs', brightness: 0, warmness: 0, account_id: 'testuser'}];
    }

    private getShutterSensors(): ShutterSensor[] {
        return [{id: '001', name: 'Shutter Livingroom', isOpen: true, account_id: 'testuser'},
    {id: '002', name: 'Shutter Kitchen', isOpen: false, account_id: 'testuser'},
    {id: '003', name: 'Shutter Bedroom', isOpen: true, account_id: 'testuser'},
    {id: '004', name: 'Shutter Terrace', isOpen: false, account_id: 'testuser'}];
    }
}