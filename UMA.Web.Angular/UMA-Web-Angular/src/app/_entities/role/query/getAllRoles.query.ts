import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { RolesViewModel } from '../reponse/roles.viewmodel';

export class GetAllRolesQuery implements IRequest<RolesViewModel> {
  _response?: RolesViewModel;
}
