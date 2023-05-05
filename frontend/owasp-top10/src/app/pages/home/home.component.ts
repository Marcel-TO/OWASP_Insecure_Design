import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    public user: User | undefined;

    constructor(private router: ActivatedRoute) {}

    ngOnInit(): void {
      this.user = this.router.snapshot.queryParams['user'];
      console.log(this.user?.username)
    }

}
