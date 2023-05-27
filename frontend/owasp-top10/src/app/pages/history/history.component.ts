import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DatabaseService } from 'src/app/components/database-services/database.service';
import { Account } from 'src/app/models/database/Account';
import { LoggedData } from 'src/app/models/database/LoggedData';
@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  public currentUser?: Account;
  public logs?: LoggedData[] = [];

  constructor(private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
  }

  async ngOnInit() {
    let id_query = this.activatedRoute.snapshot.queryParams['user'];
    let tempUser = await this.dbService.GetByIDAccount(id_query)
    
    let history = document.getElementById('history');
    let unsigned = document.getElementById('unsignedHistory');

    if (tempUser.role == 'error') {
      if (history != null) {
        history.style.display = 'none'
      }
      if (unsigned != null) {
        unsigned.style.display = 'unset'
      }
    }
    else {
      this.currentUser = tempUser;
      this.logs = await this.dbService.GetByAccountIdLoggedData(this.currentUser.account_Id);
      if (unsigned != null) {
        unsigned.style.display = 'none'
      }
    }
  }
}
