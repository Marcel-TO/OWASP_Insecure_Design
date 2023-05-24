import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './pages/home/home.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginComponent } from './pages/login/login.component';
import { BackgroundComponent } from './components/background/background.component';
import { BackgroundLeftComponent } from './components/background-left/background-left.component';
import { BackgroundMiddleComponent } from './components/background-middle/background-middle.component';
import { HistoryComponent } from './pages/history/history.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { DeviceShowcaseComponent } from './pages/device-showcase/device-showcase.component';
import { TempSettingsComponent } from './pages/temp-settings/temp-settings.component';
import { LightSettingsComponent } from './pages/light-settings/light-settings.component';
import { ShutterSettingsComponent } from './pages/shutter-settings/shutter-settings.component';
import { AddDeviceComponent } from './pages/add-device/add-device.component';

import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSliderModule} from '@angular/material/slider';
import {MatChipsModule} from '@angular/material/chips';
import {MatSidenavModule} from '@angular/material/sidenav';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NotFoundComponent,
    NavbarComponent,
    LoginComponent,
    BackgroundComponent,
    BackgroundLeftComponent,
    BackgroundMiddleComponent,
    HistoryComponent,
    DevicesComponent,
    SettingsComponent,
    DeviceShowcaseComponent,
    TempSettingsComponent,
    LightSettingsComponent,
    ShutterSettingsComponent,
    AddDeviceComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    MatIconModule,
    MatMenuModule,
    MatExpansionModule,
    MatSliderModule,
    MatChipsModule,
    MatSidenavModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
