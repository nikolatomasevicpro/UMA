import { Injectable } from '@angular/core';

import { QueryService } from '../../_base/query/query.service';
import { ConstServicesConf } from 'src/app/_models/config/consts/services.const';

import { LoginQuery } from 'src/app/_entities/authentication/query/login.query';
import { RegisterQuery } from 'src/app/_entities/authentication/query/register.query';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    constructor(private query: QueryService) {}

    register(query: RegisterQuery) {
      return this.query.typedSend(ConstServicesConf.register, query);
    }

    authenticate(query: LoginQuery) {
      return this.query.typedSend(ConstServicesConf.authenticate, query);
    }
}
