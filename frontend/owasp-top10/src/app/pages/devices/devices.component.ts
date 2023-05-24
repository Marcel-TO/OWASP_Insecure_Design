import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Account } from 'src/app/models/account';
import { Modelfactory } from 'src/app/models/modelfactory';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {
  public currentUser?: string;
  public accounts: Account[] = [];
  
  constructor(private activatedRoute: ActivatedRoute) {
    this.accounts = new Modelfactory().Accounts
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
    this.currentUser = this.checkUser(id_query);
    let devices = document.getElementById('devices');
    let unsigned = document.getElementById('unsignedDevs');
    if (this.currentUser == undefined) {
      if (devices != null) {
        devices.style.display = 'none'
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
  }
}

