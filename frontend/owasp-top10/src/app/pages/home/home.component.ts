import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    constructor(private router: Router) {
    }

    ngOnInit(): void {
      // this.user = this.router.snapshot.queryParams['user'];
    }

}
