import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';

import { ConfigurationService } from '../_base/config/configuration.service';
import { User } from '../../_models/user';
import { QueryService } from '../_base/query/query.service';
import { RegisterQuery } from 'src/app/_entities/authentication/query/register.query';
import { RegisterViewModel } from 'src/app/_entities/authentication/response/register.viewmodel';
import { LoginViewModel } from 'src/app/_entities/authentication/response/login.viewmodel';
import { LoginQuery } from 'src/app/_entities/authentication/query/login.query';
import { NotificationService } from '../_base/notification/notification.service';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(
      private config: ConfigurationService,
      private query: QueryService,
      private notification: NotificationService
      ) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(query: LoginQuery) {
      return this.query.typedSend(this.config.consts.services.authenticate, query)
      .pipe(tap(response => {
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
          localStorage.setItem('currentUser', JSON.stringify(user));
          this.currentUserSubject.next(user);
        } else {
          this.notification.error('The login and password combination is invalid', 'Authentication :');
        }
      }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }

    register(query: RegisterQuery) {
      return this.query.typedSend(this.config.consts.services.register, query);
    }
}

