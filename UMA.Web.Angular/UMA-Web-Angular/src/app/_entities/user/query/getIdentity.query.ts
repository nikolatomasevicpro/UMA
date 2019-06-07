import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { IdentityViewModel } from '../response/identity.viewmodel';

export class GetIdentityQuery implements IRequest<IdentityViewModel> {
  _response?: IdentityViewModel;
  id?: string;
  login?: string;
}
