import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public currentUser = undefined;
  public undefinedUser = undefined;
  public isSigned = false
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.currentUser  = this.activatedRoute.snapshot.queryParams['username'];
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
