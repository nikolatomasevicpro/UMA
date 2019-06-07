import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

import { QueryService } from '../../_base/query/query.service';
import { ToolsService } from '../../_base/tools/tools.service';
import { ConstServicesConf } from 'src/app/_models/config/consts/services.const';

import { GetAllRolesQuery } from 'src/app/_entities/role/query/getAllRoles.query';
import { GetRoleQuery } from 'src/app/_entities/role/query/getRole.query';
import { GetRolesByIdentityQuery } from 'src/app/_entities/role/query/getRolesByIdentity.query';
import { CreateRoleQuery } from 'src/app/_entities/role/query/createRole.query';
import { UpdateRoleQuery } from 'src/app/_entities/role/query/updateRole.query';
import { DeleteRoleQuery } from 'src/app/_entities/role/query/deleteRole.query';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(
    private query: QueryService,
    private tools: ToolsService
  ) { }

  getAllRoles(query: GetAllRolesQuery) {
    return this.query.typedSend(ConstServicesConf.getAllRoles, query).pipe(
      map(e => {
        e.roles.map(r => {
          r.created = this.tools.dateFromISO8601(r.createdDate);
          return r;
        });

        return e;
      })
    );
  }

  getRole(query: GetRoleQuery) {
    return this.query.typedSend(ConstServicesConf.getRole, query);
  }

  getRolesByIdentity(query: GetRolesByIdentityQuery) {
    return this.query.typedSend(ConstServicesConf.getRolesByIdentity, query);
  }

  createRole(query: CreateRoleQuery) {
    return this.query.typedSend(ConstServicesConf.createRole, query);
  }

  updateRole(query: UpdateRoleQuery) {
    return this.query.typedSend(ConstServicesConf.updateRole, query);
  }

  deleteRole(query: DeleteRoleQuery) {
    return this.query.typedSend(ConstServicesConf.deleteRole, query);
  }
}
