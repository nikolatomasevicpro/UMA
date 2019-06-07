import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { QueryService } from '../../_base/query/query.service';
import { ToolsService } from '../../_base/tools/tools.service';
import { ConstServicesConf } from 'src/app/_models/config/consts/services.const';

import { GetAllIdentitiesQuery } from 'src/app/_entities/user/query/getAllIdentities.query';
import { GetIdentityQuery } from 'src/app/_entities/user/query/getIdentity.query';
import { CreateIdentityQuery } from 'src/app/_entities/user/query/createIdentity.query';
import { UpdateIdentityQuery } from 'src/app/_entities/user/query/updateIdentity.query';
import { DeleteIdentityQuery } from 'src/app/_entities/user/query/deleteIdentity.query';
import { SetRolesQuery } from 'src/app/_entities/user/query/setRoles.query';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private query: QueryService,
    private tools: ToolsService
  ) { }

  getAllUsers(query: GetAllIdentitiesQuery) {
    return this.query.typedSend(ConstServicesConf.getAllUsers, query).pipe(
      map(e => {
        e.identities.map(i => {
          i.created = this.tools.dateFromISO8601(i.createdDate);
          return i;
        });

        return e;
      })
    );
  }

  getUser(query: GetIdentityQuery) {
    return this.query.typedSend(ConstServicesConf.getUser, query);
  }

  createUser(query: CreateIdentityQuery) {
    return this.query.typedSend(ConstServicesConf.createUser, query);
  }

  updateUser(query: UpdateIdentityQuery) {
    return this.query.typedSend(ConstServicesConf.updateUser, query);
  }

  deleteUser(query: DeleteIdentityQuery) {
    return this.query.typedSend(ConstServicesConf.deleteUser, query);
  }

  setRoles(query: SetRolesQuery) {
    return this.query.typedSend(ConstServicesConf.setRoles, query);
  }
}
