import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/session/user';
import { SessionService } from 'src/app/_services/_base/session/session.service';
import { UserService } from 'src/app/_services/_api/user/user.service';
import { Location } from '@angular/common';
import { NotificationService } from 'src/app/_services/_base/notification/notification.service';
import { InternationalizationService } from 'src/app/_services/_base/internationalization/internationalization.service';
import { Profile } from 'src/app/_models/session/profile';
import { Culture } from 'src/app/_models/internationalization/Culture';
import { ProfileService } from 'src/app/_services/_api/profile/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.sass']
})
export class ProfileComponent implements OnInit {
  user: User;
  profile: Profile;

  username: string;
  languages: Culture[];
  culture: Culture;

  constructor(
    private session: SessionService,
    private userService: UserService,
    private location: Location,
    private notifications: NotificationService,
    private global: InternationalizationService,
    private profileService: ProfileService
    ) {
      this.languages = this.global.cultures;
      this.session.currentUser.subscribe(u => {
        this.user = u;
        this.username = u.username;
        this.notifications.info('Got a user : ' + u.username, 'Profile :');
      }, e => this.notifications.error(e, 'Profile :'));
      this.session.currentProfile.subscribe(p => {
        this.profile = p;
        this.culture = this.languages.find(c => c.name === p.locale);
        this.notifications.info('Got a profile : ' + p.locale, 'Profile :');
      }, e => this.notifications.error(e, 'Profile :'));
  }

  ngOnInit() {
  }

  save(): void {
    this.userService.updateUser({id: this.user.id, login: this.user.username, password: null}).
    subscribe(response => {
      if (!response.result) {
        this.notifications.error(this.global.translate('Error_Profile_Update', [this.user.username]), 'Profile :');
      }
    });
  }

  goBack(): void {
    this.location.back();
  }

  updateUsername(event: any) {
  }

  changeLanguage(event: any) {
    this.notifications.info('Language selected : ' + event.name, 'Profile :');
    if (event.name !== this.profile.locale) {
      this.profileService.updateProfile({ id: this.profile.id, locale: event.name }).subscribe(response => {
        if (response.result) {
          this.profile.locale = event.name;
          this.global.switchLanguage(event.name);
        }
      });
    }
  }
}
