import { Component, OnInit } from '@angular/core';
import { RoleService } from 'src/app/_services/_api/role/role.service';
import { RoleViewModel } from 'src/app/_entities/role/reponse/role.viewmodel';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.sass']
})
export class RolesComponent implements OnInit {
  roles: RoleViewModel[];

  constructor(
    private roleService: RoleService
  ) { }

  ngOnInit() {
    this.getRoles();
  }

  getRoles() {
    this.roleService.getAllRoles({}).subscribe(response => this.roles = response.roles);
  }


  public add(name: string, description: string) {
    name = name.trim();
    description = description.trim();
    if (!name || !description) { return; }
    this.roleService.createRole({ name, description }).subscribe(response => {
      if (response.result) {
        this.roles.push({ id: response.id
          , name
          , description
          , result: response.result
          , message: response.message
        , created: new Date()
      , createdDate: new Date().toISOString()});
      }
    });
  }

  delete(role: RoleViewModel) {
    const id = role.id;
    this.roleService.deleteRole(role).subscribe(response => {
      if (response.result) {
        this.roles = this.roles.filter(e => e.id !== id);
      }
    });
  }
}

