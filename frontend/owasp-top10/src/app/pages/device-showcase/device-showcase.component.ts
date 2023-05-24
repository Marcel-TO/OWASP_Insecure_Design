import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-device-showcase',
  templateUrl: './device-showcase.component.html',
  styleUrls: ['./device-showcase.component.scss']
})
export class DeviceShowcaseComponent {
  public degree = 20
  
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
}
