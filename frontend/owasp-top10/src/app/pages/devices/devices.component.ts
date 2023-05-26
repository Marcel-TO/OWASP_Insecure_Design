import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {
  public currentUser?: Account;
  
  constructor(private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
  }

  async ngOnInit() {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    let tempUser = await this.dbService.GetByIDAccount(id_query);
    let devices = document.getElementById('devices');
    let unsigned = document.getElementById('unsignedDevs');

    
    if (tempUser.role == 'error') {
      if (devices != null) {
        devices.style.display = 'none'
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      this.currentUser = tempUser;
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}

