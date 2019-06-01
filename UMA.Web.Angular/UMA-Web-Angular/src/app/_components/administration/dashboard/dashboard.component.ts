import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/_api/user/user.service';
import { IdentityViewModel } from 'src/app/_entities/user/response/identity.viewmodel';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass']
})
export class DashboardComponent implements OnInit {
  users: IdentityViewModel[];
  userNb = 5;

  constructor(
    private usersService: UserService
  ) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.usersService.getAllUsers({}).subscribe(response =>
      this.users = response.identities.sort((a, b) => {
        if (a.created.getTime() === b.created.getTime()) {
          return 0;
        } else if (a.created.getTime() < b.created.getTime()) {
          return -1;
        } else {
          return 1;
        }
      }).reverse().slice(0, this.userNb < response.identities.length ? this.userNb : response.identities.length));
  }
}

