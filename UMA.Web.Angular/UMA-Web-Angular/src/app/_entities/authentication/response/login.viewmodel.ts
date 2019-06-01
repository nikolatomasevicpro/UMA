import { BaseViewModel } from '../../base/base.viewmodel';

export class LoginViewModel extends BaseViewModel {
  id: string;
  token: string;
  login: string;
  expires: string;
  roles: string[];
}
