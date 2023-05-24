import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Account } from 'src/app/models/account';
import { Modelfactory } from 'src/app/models/modelfactory';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.scss']
})
export class HistoryComponent implements OnInit {
  public currentUser?: string;
  public accounts: Account[] = [];

  constructor(private activatedRoute: ActivatedRoute) {
    this.accounts = new Modelfactory().Accounts;
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
    this.currentUser = this.activatedRoute.snapshot.queryParams['user'];
    // let history = document.getElementById('history');
    let unsigned = document.getElementById('unsignedHistory');
    if (this.currentUser == undefined) {
      // if (history != null) {
      //   history.style.display = 'none'
      // }
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
