import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { DeleteRoleViewModel } from '../reponse/deleteRole.viewmodel';

export class DeleteRoleQuery implements IRequest<DeleteRoleViewModel> {
  _response?: DeleteRoleViewModel;
  id: string;
}
