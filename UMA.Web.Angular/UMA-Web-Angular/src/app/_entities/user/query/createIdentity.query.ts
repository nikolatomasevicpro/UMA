import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { CreateIdentityViewModel } from '../response/createidentity.viewmodel';

export class CreateIdentityQuery implements IRequest<CreateIdentityViewModel> {
  _response?: CreateIdentityViewModel;
  login: string;
  password: string;
}
