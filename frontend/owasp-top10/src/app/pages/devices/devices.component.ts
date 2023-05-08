import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Sensor } from 'src/app/models/sensor';
import { Actuator } from 'src/app/models/actuator';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {
  public currentUser?: string;
  
  constructor(private activatedRoute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.currentUser = this.activatedRoute.snapshot.queryParams['username'];
    let devices = document.getElementById('devices');
    let unsigned = document.getElementById('unsignedDevs');
    console.log(this.currentUser)
    console.log(unsigned)
    if (this.currentUser == undefined) {
      if (devices != null) {
        devices.style.display = 'none'
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
        console.log('changed')
      }
    }
    else {
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}

