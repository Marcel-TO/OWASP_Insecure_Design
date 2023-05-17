import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { HistoryComponent } from './pages/history/history.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { DeviceShowcaseComponent } from './pages/device-showcase/device-showcase.component';
import { TempSettingsComponent } from './pages/temp-settings/temp-settings.component';
import { LightSettingsComponent } from './pages/light-settings/light-settings.component';
import { ShutterSettingsComponent } from './pages/shutter-settings/shutter-settings.component';
import { AddDeviceComponent } from './pages/add-device/add-device.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'devices', component: DevicesComponent},
  {path: 'history', component: HistoryComponent},
  {path: 'settings', component: SettingsComponent},
  {path: 'settings/add-device', component: AddDeviceComponent},
  {path: 'devices/temp-settings', component: TempSettingsComponent},
  {path: 'devices/light-settings', component: LightSettingsComponent},
  {path: 'devices/shutter-settings', component: ShutterSettingsComponent},
  {path: 'device-showcase', component: DeviceShowcaseComponent},
  {path: '**', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
