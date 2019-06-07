import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { AuthenticationService } from '../../_api/authentication/authentication.service';
import { ConfigurationService } from '../config/configuration.service';
import { ToolsService } from '../tools/tools.service';
import { User } from 'src/app/_models/session/user';
import { LoginQuery } from 'src/app/_entities/authentication/query/login.query';
import { NotificationService } from '../notification/notification.service';
import { ProfileService } from '../../_api/profile/profile.service';
import { RegisterQuery } from 'src/app/_entities/authentication/query/register.query';
import { RegisterViewModel } from 'src/app/_entities/authentication/response/register.viewmodel';
import { Profile } from 'src/app/_models/session/profile';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private currentUserName = 'currentUser';
  private currentProfileName = 'currentProfile';

  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;

  private currentProfileSubject: BehaviorSubject<Profile>;
  public currentProfile: Observable<Profile>;

  constructor(
    private authentication: AuthenticationService,
    private config: ConfigurationService,
    private tools: ToolsService,
    private notification: NotificationService,
    private profileService: ProfileService
    ) {
        this.currentUserSubject = new BehaviorSubject<User>(
          JSON.parse(localStorage.getItem(this.currentUserName)));
        this.currentUser = this.currentUserSubject.asObservable();

        this.currentProfileSubject = new BehaviorSubject<Profile>(
          JSON.parse(localStorage.getItem(this.currentProfileName)));
        this.currentProfile = this.currentProfileSubject.asObservable();
    }

  public get isAuthentified(): boolean {
    return !!this.user;
  }

  hasPolicy(policy: string): boolean {
    return this.isAuthentified && this.config.applicablePolicies(this.user.roles)
                                                              .some(e => e.toLowerCase() === policy.toLowerCase());
  }

  public get hasExpired(): boolean {
    return !this.isAuthentified || this.tools.ticksFromISO8601(this.user.expires) < (new Date()).getTime();
  }

  public get user(): User {
    return this.currentUserSubject.value;
  }

  public get profile(): Profile {
    return this.currentProfileSubject.value;
  }

  public login(query: LoginQuery): Observable<User> {
    this.authentication.authenticate(query)
    .subscribe(response => {
      if (response.result) {
        const user = {
          id: response.id,
          username: response.login,
          token: response.token,
          expires: response.expires,
          roles: response.roles,
          policies: this.config.applicablePolicies(response.roles)
        } as User;

        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem(this.currentUserName, JSON.stringify(user));
        this.currentUserSubject.next(user);

        this.profileService.getProfile({identityid: user.id}).subscribe(subResponse => {
          if (subResponse.result) {
            const profile = {
              id: subResponse.id,
              locale: subResponse.locale
            } as Profile;

            this.notification.success('Profile retrieved. Locale set to "' + profile.locale + '"', 'Session :');
            // store user profile in local storage to keep user profile in between page refreshes
            localStorage.setItem(this.currentProfileName, JSON.stringify(profile));
            this.currentProfileSubject.next(profile);

          } else {
              this.notification.error('The retrieval of the profile failed', 'Session :');
          }
        });
      } else {
        this.notification.error('The login and password combination is invalid', 'Session :');
      }
    });

    return this.currentUser;
  }

  public logout() {
    // remove user from local storage to log user out
    localStorage.removeItem(this.currentUserName);
    this.currentUserSubject.next(null);

    // also remove user profile
    localStorage.removeItem(this.currentProfileName);
    this.currentProfileSubject.next(null);

    this.notification.success('Loged out', 'Session : ');
  }

  public register(query: RegisterQuery): Observable<RegisterViewModel> {
    return this.authentication.register(query);
  }
}
