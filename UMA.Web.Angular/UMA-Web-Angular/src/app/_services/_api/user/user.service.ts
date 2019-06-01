import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ConfigurationService } from '../../_base/config/configuration.service';
import { QueryService } from '../../_base/query/query.service';

import { IdentitiesViewModel } from 'src/app/_entities/user/response/identities.viewmodel';
import { IdentityViewModel } from 'src/app/_entities/user/response/identity.viewmodel';
import { UpdateIdentityViewModel } from 'src/app/_entities/user/response/updateidentity.viewmodel';
import { DeleteIdentityViewModel } from 'src/app/_entities/user/response/deleteidentity.viewmodel';
import { CreateIdentityViewModel } from 'src/app/_entities/user/response/createidentity.viewmodel';
import { map } from 'rxjs/operators';
import { ToolsService } from '../../_base/tools/tools.service';
import { SetRolesQuery } from 'src/app/_entities/user/query/setRoles.query';
import { SetRolesViewModel } from 'src/app/_entities/user/response/setRoles.viewmodel';
import { GetAllRolesQuery } from 'src/app/_entities/role/query/getAllRoles.query';
import { GetIdentityQuery } from 'src/app/_entities/user/query/getIdentity.query';
import { CreateIdentityQuery } from 'src/app/_entities/user/query/createIdentity.query';
import { DeleteIdentityQuery } from 'src/app/_entities/user/query/deleteIdentity.query';
import { UpdateIdentityQuery } from 'src/app/_entities/user/query/updateIdentity.query';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private query: QueryService,
    private config: ConfigurationService,
    private tools: ToolsService
  ) { }

  getAllUsers(query: GetAllRolesQuery): Observable<IdentitiesViewModel> {
    return this.query.send<IdentitiesViewModel>(this.config.consts.services.getAllUsers, null).pipe(
      map(e => {
        e.identities.map(i => i.created = this.tools.dateFromISO8601(i.createdDate));
        return e;
      })
    );
  }

  getUser(query: GetIdentityQuery): Observable<IdentityViewModel> {
    return this.query.send<IdentityViewModel>(this.config.consts.services.getUser, query);
  }

  createUser(query: CreateIdentityQuery): Observable<CreateIdentityViewModel> {
    return this.query.send<CreateIdentityViewModel>(this.config.consts.services.createUser, query);
  }

  updateUser(query: UpdateIdentityQuery): Observable<UpdateIdentityViewModel> {
    return this.query.send<UpdateIdentityViewModel>(this.config.consts.services.updateUser, query);
  }

  deleteUser(query: DeleteIdentityQuery): Observable<DeleteIdentityViewModel> {
    return this.query.send<DeleteIdentityViewModel>(this.config.consts.services.deleteUser, query);
  }

  setRoles(query: SetRolesQuery): Observable<SetRolesViewModel> {
    return this.query.send<SetRolesViewModel>(this.config.consts.services.setRoles, query);
  }
}
