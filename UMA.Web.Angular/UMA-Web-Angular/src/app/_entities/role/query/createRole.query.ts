import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { CreateRoleViewModel } from '../reponse/createRole.viewmodel';

export class CreateRoleQuery implements IRequest<CreateRoleViewModel> {
  _response?: CreateRoleViewModel;
  name: string;
  description: string;
}
