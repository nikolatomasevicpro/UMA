import { IRequest } from 'src/app/_models/interfaces/IRequest';
import { DeleteIdentityViewModel } from '../response/deleteidentity.viewmodel';

export class DeleteIdentityQuery implements IRequest<DeleteIdentityViewModel> {
  _response?: DeleteIdentityViewModel;
  id: string;
}
