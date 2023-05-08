import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-device-showcase',
  templateUrl: './device-showcase.component.html',
  styleUrls: ['./device-showcase.component.scss']
})
export class DeviceShowcaseComponent implements OnInit {
  public degree = 20
  public currentUser = undefined;
  
  constructor(private activatedRoute: ActivatedRoute) {}

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
    let devices = document.getElementById('devices');
    let unsigned = document.getElementById('unsignedDeviceShowcase');
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
