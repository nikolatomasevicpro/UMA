import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';
import { RoleService } from '../../../_services/_api/role/role.service';
import { RoleViewModel } from '../../../_entities/role/reponse/role.viewmodel';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.sass']
})

export class RoleComponent implements OnInit {
  @Input() role: RoleViewModel;

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private roleService: RoleService
  ) { }

  ngOnInit() {
    this.getRole();
  }

  getRole() {
    const id = this.route.snapshot.paramMap.get('id');
    this.roleService.getRole({ id })
    .subscribe(response => this.role = response);
  }

  save(): void {
    this.roleService.updateRole( { id: this.role.id, name: this.role.name, description: this.role.description}).
    subscribe(() => this.goBack());
  }

  goBack(): void {
    this.location.back();
  }
}
