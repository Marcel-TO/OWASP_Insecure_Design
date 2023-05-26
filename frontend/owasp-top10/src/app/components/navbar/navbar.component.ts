import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatabaseService } from '../database-services/database.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public currentUser?: string;
  public isSigned = false

  constructor(private router: Router, private activatedRoute: ActivatedRoute, private dbService: DatabaseService) {
  }

  async ngOnInit() {
    let id_query  = this.activatedRoute.snapshot.queryParams['user'];
    let tempUser = await this.dbService.GetByIDAccount(id_query);
    if (tempUser.role == 'error') {
      this.isSigned = false;
    }
    else {
      this.currentUser = tempUser.account_Id;
      this.isSigned = true;
    }
  }

  public onLogout() {
    this.currentUser = undefined;
    this.isSigned = false;
    this.router.navigate(['/']);
  }

}
