import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/_api/user/user.service';
import { IdentityViewModel } from 'src/app/_entities/user/response/identity.viewmodel';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.sass']
})
export class UsersComponent implements OnInit {
  users: IdentityViewModel[];

  constructor(
    private userService: UserService
  ) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.userService.getAllUsers({}).subscribe(response => this.users = response.identities);
  }

  public add(login: string, password: string) {
    login = login.trim();
    password = password.trim();
    if (!login || !password) { return; }
    this.userService.createUser({login, password}).subscribe(response => {
      if (response.result) {
        this.users.push({ login
          , id: response.id
          , result: response.result
          , message: response.message
        , created: new Date()
      , createdDate: new Date().toISOString()});
      }
    });
  }

  delete(user: IdentityViewModel) {
    const id = user.id;
    this.userService.deleteUser({id}).subscribe(response => {
      if (response.result) {
        this.users = this.users.filter(e => e.id !== id);
      }
    });
  }
}
