import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { SetRolesViewModel } from '../response/setRoles.viewmodel';

export class SetRolesQuery implements IRequest<SetRolesViewModel> {
  _response?: SetRolesViewModel;
  identity: string;
  roles: string[];
}
