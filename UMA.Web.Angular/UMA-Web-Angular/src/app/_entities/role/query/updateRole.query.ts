import { UpdateRoleViewModel } from '../reponse/updateRole.viewmodel';
import { IRequest } from 'src/app/_models/interfaces/IRequest';

export class UpdateRoleQuery implements IRequest<UpdateRoleViewModel> {
  _response?: UpdateRoleViewModel;
  id: string;
  name: string;
  description: string;
}
