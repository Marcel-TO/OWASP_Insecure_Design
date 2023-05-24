import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Account } from 'src/app/models/account';
import { Modelfactory } from 'src/app/models/modelfactory';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public currentUser?: string;
  public isSigned = false
  public accounts: Account[] = [];

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {
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
    let id_query  = this.activatedRoute.snapshot.queryParams['user'];
    this.currentUser = this.checkUser(id_query);
    console.log(this.currentUser)
    if (this.currentUser != undefined) {
      this.isSigned = true;
    }
    else {
      this.isSigned = false;
    }
  }

  public onLogout() {
    this.currentUser = undefined;
    this.isSigned = false;
    this.router.navigate(['/']);
  }

}
