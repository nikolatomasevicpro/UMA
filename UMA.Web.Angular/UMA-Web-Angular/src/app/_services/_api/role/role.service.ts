import { Injectable } from '@angular/core';
import { ConfigurationService } from '../../_base/config/configuration.service';
import { QueryService } from '../../_base/query/query.service';
import { Observable } from 'rxjs';
import { RolesViewModel } from 'src/app/_entities/role/reponse/roles.viewmodel';
import { ToolsService } from '../../_base/tools/tools.service';
import { map } from 'rxjs/operators';
import { RoleViewModel } from 'src/app/_entities/role/reponse/role.viewmodel';
import { CreateRoleViewModel } from 'src/app/_entities/role/reponse/createRole.viewmodel';
import { UpdateRoleViewModel } from 'src/app/_entities/role/reponse/updateRole.viewmodel';
import { DeleteRoleViewModel } from 'src/app/_entities/role/reponse/deleteRole.viewmodel';
import { GetAllRolesQuery } from 'src/app/_entities/role/query/getAllRoles.query';
import { GetRoleQuery } from 'src/app/_entities/role/query/getRole.query';
import { CreateRoleQuery } from 'src/app/_entities/role/query/createRole.query';
import { UpdateRoleQuery } from 'src/app/_entities/role/query/updateRole.query';
import { DeleteRoleQuery } from 'src/app/_entities/role/query/deleteRole.query';
import { GetRolesByIdentityQuery } from 'src/app/_entities/role/query/getRolesByIdentity.query';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  constructor(
    private config: ConfigurationService,
    private query: QueryService,
    private tools: ToolsService
  ) { }

  getAllRoles(query: GetAllRolesQuery): Observable<RolesViewModel> {
    return this.query.send<RolesViewModel>(this.config.consts.services.getAllRoles, query).pipe(
      map(e => {
        e.roles.map(r => {
          r.created = this.tools.dateFromISO8601(r.createdDate);
          return r;
        });

        return e;
      })
    );
  }

  getRole(query: GetRoleQuery): Observable<RoleViewModel> {
    return this.query.send<RoleViewModel>(this.config.consts.services.getRole, query);
  }

  getRolesByIdentity(query: GetRolesByIdentityQuery): Observable<RolesViewModel> {
    return this.query.send<RolesViewModel>(this.config.consts.services.getRolesByIdentity, query);
  }

  createRole(query: CreateRoleQuery): Observable<CreateRoleViewModel> {
    return this.query.send<CreateRoleViewModel>(this.config.consts.services.createRole, query);
  }

  updateRole(query: UpdateRoleQuery): Observable<UpdateRoleViewModel> {
    return this.query.send<UpdateRoleViewModel>(this.config.consts.services.updateRole, query);
  }

  deleteRole(query: DeleteRoleQuery): Observable<DeleteRoleViewModel> {
    return this.query.send<DeleteRoleViewModel>(this.config.consts.services.deleteRole, query);
  }
}
