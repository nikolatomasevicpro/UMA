import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { RoleViewModel } from '../reponse/role.viewmodel';

export class GetRoleQuery implements IRequest<RoleViewModel> {
  _response?: RoleViewModel;
  id?: string;
  name?: string;
  description?: string;
}
