import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/models/account';
import { Modelfactory } from 'src/app/models/modelfactory';

@Component({
  selector: 'app-add-device',
  templateUrl: './add-device.component.html',
  styleUrls: ['./add-device.component.scss']
})
export class AddDeviceComponent {
  public degree = 20
  public currentUser?: string;
  public accounts: Account[] = [];
  
  constructor(private activatedRoute: ActivatedRoute) {
    let modelfactory = new Modelfactory()
    this.accounts = modelfactory.Accounts
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

  private checkUser(id:string) {
    for (let user of this.accounts) {
      if (id == user.id) {
        return id;
      }
    }
    return undefined
  }

  ngOnInit(): void {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    this.currentUser = this.checkUser(id_query)

    let devices = document.getElementById('addDevices');
    let unsigned = document.getElementById('unsignedAddDeviceShowcase');
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
