import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from 'src/app/_models/user';
import { AuthenticationService } from 'src/app/_services/authentication/authentication.service';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { ConfigurationService } from 'src/app/_services/_base/config/configuration.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent implements OnInit {
  currentUser: User;
  userisAdmin: boolean;

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private session: SessionService,
    private conf: ConfigurationService
    ) {
      this.authenticationService.currentUser.subscribe(x => { this.currentUser = x; this.checkClaims(); });
     }

  ngOnInit() {
  }

  private checkClaims() {
    if (this.currentUser && this.currentUser.roles) {
    this.userisAdmin = this.session.hasPolicy(this.conf.consts.policies.admin);
    }
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
