import { Injectable } from '@angular/core';
import { AuthenticationService } from '../../authentication/authentication.service';
import { ConfigurationService } from '../config/configuration.service';
import { ToolsService } from '../tools/tools.service';
import { User } from 'src/app/_models/user';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private authentication: AuthenticationService,
              private config: ConfigurationService,
              private tools: ToolsService
              ) { }

  public get isAuthentified(): boolean {
    return !!this.authentication.currentUserValue;
  }

  hasPolicy(policy: string): boolean {
    return this.isAuthentified && this.config.applicablePolicies(this.authentication.currentUserValue.roles)
                                                              .some(e => e.toLowerCase() === policy.toLowerCase());
  }

  public get hasExpired(): boolean {
    return !this.isAuthentified || this.tools.ticksFromISO8601(this.authentication.currentUserValue.expires) < (new Date()).getTime();
  }

  public get user(): User {
    return this.authentication.currentUserValue;
  }
}
