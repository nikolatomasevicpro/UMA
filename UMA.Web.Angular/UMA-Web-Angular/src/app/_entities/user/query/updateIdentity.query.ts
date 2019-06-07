import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { UpdateIdentityViewModel } from '../response/updateidentity.viewmodel';

export class UpdateIdentityQuery implements IRequest<UpdateIdentityViewModel> {
  _response?: UpdateIdentityViewModel;
  id: string;
  login: string;
  password: string;
}
