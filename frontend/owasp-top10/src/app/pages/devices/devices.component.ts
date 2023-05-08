import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {
  public currentUser?: string;
  public items?: string[];
  public degree = 20;
  public isOpen = false;
  
  constructor(private activatedRoute: ActivatedRoute) {
  }

  public onClickDrawer() {
    let drawer = document.getElementById('drawer');
    let menu = document.getElementById('tempMenu');

    if (this.isOpen) {
      this.isOpen = false;
      if (menu != null) {
        menu.style.display = "none";
      }
      if (drawer != null) {
        // toggle drawer
      }
    }
  }

  public onIncreaseTemp() {
    if (this.degree < 30) {
      this.degree += 1;
    }
  }

  public onDegreaseTemp() {
    if (this.degree > 14) {
      this.degree -= 1;
    }
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
    let unsigned = document.getElementById('unsignedDevices');
    let devices = document.getElementById('device');
    if (this.currentUser == undefined) {
      if (devices != null) {
        devices.style.display = "none"
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
    
    this.items = ['Temp 1', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Tempdfjasdjföasdjföj 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3', 'Temp 2', 'Temp 3'];
  }
}
