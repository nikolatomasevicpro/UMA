import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { User } from 'src/app/_models/session/user';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { ConfigurationService } from 'src/app/_services/_base/config/configuration.service';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';
import { ConstPoliciesConf } from 'src/app/_models/config/consts/policies.const';

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
    private session: SessionService,
    private conf: ConfigurationService,
    private notif: NotificationService
    ) {
      this.session.currentUser.subscribe(x => {
        this.currentUser = x;
        this.checkClaims();
        this.notif.info('Checked user credentials', 'Header :');
      });
     }

  ngOnInit() {
  }

  private checkClaims() {
    if (this.currentUser && this.currentUser.roles) {
    this.userisAdmin = this.session.hasPolicy(ConstPoliciesConf.admin);
    }
  }

  logout() {
    this.session.logout();
    this.router.navigate(['/login']);
  }
}
