import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SmartJalousine } from 'src/app/models/database/Shutter/SmartJalousine';

@Component({
  selector: 'app-shutter-settings',
  templateUrl: './shutter-settings.component.html',
  styleUrls: ['./shutter-settings.component.scss']
})
export class ShutterSettingsComponent {
  // public currentUser?: string;
  // public currentSensor?: SmartJalousine;

  // // public accounts: Account[] = [];
  // // public sensors: ShutterSensor[] = [];
  // // public shutterOpen: boolean = false;
  // // public isOpen = false;
  // // private modelFactory = new Modelfactory();
  
  // constructor(private activatedRoute: ActivatedRoute) {
  //   // this.accounts = this.modelFactory.Accounts;
  // }

  // public onClickDrawer() {
  //   let menu = document.getElementById('shutterMenu');

  //   if (this.isOpen) {
  //     this.isOpen = false;
  //     if (menu != null) {
  //       menu.style.display = "none";
  //     }
  //   }
  // }

  // public onChangeShutter() {
  //   this.shutterOpen = !this.shutterOpen;
  // }

  // public selectDevice(sensor: ShutterSensor) {
  //   this.currentSensor = sensor;
  //   this.shutterOpen = this.currentSensor.isOpen;
  // }

  // private checkUser(id:string) {
  //   for (let user of this.accounts) {
  //     if (id == user.id) {
  //       return id;
  //     }
  //   }
  //   return undefined
  // }

  // ngOnInit(): void {
  //   let id_query = this.activatedRoute.snapshot.queryParams['user'];
  //   this.currentUser = this.checkUser(id_query);

  //   let unsigned = document.getElementById('unsignedShutterSettings');
  //   let devices = document.getElementById('device');
  //   if (this.currentUser == undefined) {
  //     if (devices != null) {
  //       devices.style.display = "none"
  //     }
  //     if (unsigned != null) {
  //       unsigned.style.display = 'unset'
  //     }
  //   }
  //   else {
  //     if (unsigned != null) {
  //       unsigned.style.display = 'none'
  //     }
  //     this.sensors = this.modelFactory.getShutterSensors(this.currentUser)
  //   }
  // }
}
