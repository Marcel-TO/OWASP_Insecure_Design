import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent {
  public user;
  constructor(private router: Router) {
    this.user = this.router.getCurrentNavigation()?.extras.state;
    if (this.user != null) {
      let unsigned = document.getElementById('not-signedin');
      let signed = document.getElementById('signedin');
      console.log(unsigned)
      if (signed != null) {
        signed.style.visibility = 'visible';
        console.log("set signed")
      }
      if (unsigned != null) {
        unsigned.style.visibility = 'hidden'
        console.log("hide unsign")
      }
    }
  }

}
