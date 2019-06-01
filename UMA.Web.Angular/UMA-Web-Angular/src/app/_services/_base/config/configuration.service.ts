import { Injectable, OnInit } from '@angular/core';

import { ApiEndpointConf } from 'src/app/_models/config/api-endpoints';
import { Config } from '../../../_models/config/config';
import { ConstsConf } from 'src/app/_models/config/consts/consts';
import { PolicyConf } from 'src/app/_models/config/policy';

import configFile from '../../../_data/config.json';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService implements OnInit {
  config: Config = configFile;
  consts: ConstsConf = new ConstsConf();

  constructor() { }

  ngOnInit(): void {}

  getApiEndpointForService(service: string): ApiEndpointConf {
    if (service.trim()) {
      const obj = this.config.apiEndpoints.find(e => e.service === service);
      if (obj) {
        return obj;
      }
    }

    return null;
  }

  hasRole(policy: PolicyConf, role: string): boolean {
    return policy.roles.some(e => e.toLowerCase() === role.toLowerCase());
  }

  applicablePolicies(roles: string[]): string[] {
    return this.config.policies.filter(e => roles.some(r => this.hasRole(e, r))).map(e => e.name);
  }
}
