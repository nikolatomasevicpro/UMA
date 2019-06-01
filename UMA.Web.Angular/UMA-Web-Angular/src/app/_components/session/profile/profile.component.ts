import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { UserService } from 'src/app/_services/_api/user/user.service';
import { Location } from '@angular/common';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';
import { InternationalizationService } from 'src/app/_services/_base/internationalization/internationalization.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.sass']
})
export class ProfileComponent implements OnInit {
  user: User;
  languages: string[];
  language: string;

  constructor(
    private session: SessionService,
    private userService: UserService,
    private location: Location,
    private notifications: NotificationService,
    private global: InternationalizationService
    ) {
    this.user = session.user;
    this.languages = this.global.languages;
  }

  ngOnInit() {
  }

  save(): void {
    this.userService.updateUser({id: this.user.id, login: this.user.username, password: null}).
    subscribe(response => {
      if (!response.result) {
        this.notifications.error('Failed to update profile : ' + response.message, 'Profile :');
      }
    });
  }

  goBack(): void {
    this.location.back();
  }

  changeLanguage(event: any) {
    this.notifications.info('Language selected', 'Profile :');
  }
}
