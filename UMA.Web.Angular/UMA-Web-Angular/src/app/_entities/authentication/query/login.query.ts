import { LoginViewModel } from '../response/login.viewmodel';
import { IRequest } from 'src/app/_models/interfaces/IRequest';

export class LoginQuery implements IRequest<LoginViewModel> {
  _response?: LoginViewModel;
  login: string;
  password: string;
}
