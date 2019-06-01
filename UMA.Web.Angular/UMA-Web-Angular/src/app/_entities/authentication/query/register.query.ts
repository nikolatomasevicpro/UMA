import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { RegisterViewModel } from '../response/register.viewmodel';

export class RegisterQuery implements IRequest<RegisterViewModel> {
  _response?: RegisterViewModel;
  login: string;
  password: string;
}
